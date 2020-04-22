
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using News24.Data.ApplicationContext;
using News24.Data.Identity;
using News24.Data.Infrastructure;
using News24.Data.Repositories;
using News24.Model;
using News24.Service;
using News24.Web.App_Start;
using Owin;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[assembly: OwinStartup(typeof(News24.Web.Startup))]

namespace News24.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);
            IdentityStartup.ConfigureAuth(app);
        }

        public static void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();
            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationRoleStore>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<EmailService>().As<IEmailService>().InstancePerRequest();
            builder.RegisterType<SmsService>().As<ISmsService>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ArticleRepository).Assembly).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
