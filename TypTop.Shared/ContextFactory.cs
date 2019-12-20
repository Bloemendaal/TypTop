using Microsoft.EntityFrameworkCore.Design;
using TypTop.Database;

namespace TypTop.Shared
{
    /// <summary>
    /// Wordt gebruikt voor ef migrations en Databaseconnectie
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            return new Context(Settings.Instance.DatabaseConnectionString);
        }
    }
}