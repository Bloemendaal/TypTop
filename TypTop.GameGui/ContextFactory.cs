using Microsoft.EntityFrameworkCore.Design;
using TypTop.Database;

namespace TypTop.GameGui
{
    /// <summary>
    /// Wordt gebruikt voor ef migrations
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            return new Context(Settings.Instance.DatabaseConnectionString);
        }
    }
}