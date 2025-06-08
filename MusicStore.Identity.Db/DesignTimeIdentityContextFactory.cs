using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MusicStore.Identity.Db;

public class DesignTimeIdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
{
    public IdentityDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();

        // Connection string na sztywno – NIE z appsettings.json
        optionsBuilder.UseSqlite("Data Source=identity.db");

        return new IdentityDbContext(optionsBuilder.Options);
    }
}
