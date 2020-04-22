using News24.Web.Mappings;

namespace News24.Web.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            AutoMapperConfiguration.Configure();
        }
    }
}