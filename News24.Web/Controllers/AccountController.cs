﻿
using Coco.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using News24.Data.Identity;
using News24.Model;
using News24.Web.Extensions;
using News24.Web.ViewModels.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace News24.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;


        public AccountController(ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        // GET: /Account/Login
        [OnlyAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [OnlyAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, shouldLockout: false).ConfigureAwait(false);

            switch (result)
            {
                case SignInStatus.Success:
                    Logger.Log.Info($"Пользователь {model.Email} зашел на сайт");
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                //case SignInStatus.RequiresVerification:
                //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = true });
                default:
                    ModelState.AddModelError(string.Empty, @"Неверные данные.");
                    return View(model);
            }
        }

        // GET: /Account/Register
        [OnlyAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register  
        [HttpPost]
        [OnlyAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.Phone, AccountImage = model.AccountImage.ToByteArray() };
       
                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByEmailAsync(user.Email).ConfigureAwait(false);
                    await _userManager.AddToRoleAsync(currentUser.Id, "User").ConfigureAwait(false);
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: true).ConfigureAwait(false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id).ConfigureAwait(false);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code }, protocol: Request.Url.Scheme);
                    await _userManager.SendEmailAsync(
                            user.Id,
                            "Подтвердите электронную почту",
                            "Чтобы подтвердить регистрацию <a href=\"" + callbackUrl + "\">кликните здесь</a>")
                        .ConfigureAwait(false);

                    Logger.Log.Info($"Был зарегистрирован новый пользователь {user.Email}");
                    return View("DisplayEmail");
                }


                ModelState.AddModelErrors(result.Errors.Select(x => new ValidationResult(x)));

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(userId, code).ConfigureAwait(false);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [OnlyAnonymous]
        public ActionResult ForgotPassword()
        {
            return PartialView("_ForgotPassword");
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email).ConfigureAwait(false);
                if (user == null)
                {
                    // Don't reveal that the user does not exist
                    return PartialView("_ForgotPasswordConfirmationFailure");
                }

                // Send an email with this link
                var code = await _userManager.GeneratePasswordResetTokenAsync(user.Id).ConfigureAwait(false);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code }, protocol: Request.Url.Scheme);
                await _userManager.SendEmailAsync(user.Id, "Восстановаление пароля", "Сбросьте пароль нажав <a href=\"" + callbackUrl + "\">здесь</a>").ConfigureAwait(false);
                return PartialView("_ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return PartialView("_ForgotPassword", model);
        }

        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return PartialView("_ForgotPasswordConfirmation");
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmationFailure()
        {
            return PartialView("_ForgotPasswordConfirmationFailure");
        }
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Email).ConfigureAwait(false);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.Password).ConfigureAwait(false);
            if (result.Succeeded)
            {
                Logger.Log.Info($"Пользователь {user.Email} сбросил пароль");
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            ModelState.AddModelErrors(result.Errors.Select(x => new ValidationResult(x)));
            return View();
        }

        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        // POST: /Account/LogOff
        [HttpPost]
        [System.Web.Mvc.Authorize]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Start");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Start");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            // Used for XSRF protection when adding external logins
            private const string XsrfKey = "XsrfId";

            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }

            public string RedirectUri { get; set; }

            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }

                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
    }
}