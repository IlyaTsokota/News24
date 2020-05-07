using AutoMapper;
using Microsoft.AspNet.Identity;
using News24.Data.Identity;
using News24.Model;
using News24.Web.Areas.Admin.ViewModels.UserViewModels;
using News24.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace News24.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly ApplicationUserManager _userManager;
        private const int _pageSize = 10;
        public UserController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }
        // GET: Admin/User
        public ActionResult Index(bool onlyBlocked = false, bool onlyUnlock = false, int page = 1)
        {
            onlyBlocked = onlyBlocked == false ? onlyUnlock : onlyBlocked;
            var users = _userManager.GetUsers(onlyBlocked);
            var userList = users.Select(Mapper.Map<User, UserViewModel>).Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pager = new Pager(page, users.Count(), _pageSize);
            var model = new IndexUserViewModel
            {
                Pager = pager,
                Users = userList,
                Blocked = onlyBlocked
            };
            return View(model);
        }
       
        public ActionResult Details(string id, string msg = null)
        {
            ViewData["Message"] = msg;
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }
            var model = Mapper.Map<User, DetailsUserViewModel>(user);
            model.IsBlocked = user.LockoutEndDateUtc > DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Block(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

           
            await _userManager.SetLockoutEnabledAsync(user.Id, true).ConfigureAwait(false);
            await _userManager.SetLockoutEndDateAsync(user.Id, DateTimeOffset.MaxValue).ConfigureAwait(false);
            await _userManager.UpdateSecurityStampAsync(user.Id).ConfigureAwait(false);
            Logger.Log.Info($"{User.Identity.Name} заблокировал пользователя {user.UserName}");
            return RedirectToAction("Details", new { id });
        }
        [HttpPost]
        public async Task<ActionResult> Unblock(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            await _userManager.SetLockoutEndDateAsync(user.Id, DateTimeOffset.Now).ConfigureAwait(false);
            Logger.Log.Info($"{User.Identity.Name}  разблокировал пользователя {user.UserName}");
            return RedirectToAction("Details", new { id });
        }
    }
}