

namespace News24.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        ApplicationContext.ApplicationContext Get();
    }
}
