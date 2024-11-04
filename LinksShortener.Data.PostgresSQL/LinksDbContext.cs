using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LinksShortener.Data.PostgresSQL
{
    public sealed class LinksDbContext : DbContext
    {
        public DbSet<ShortLinkMapEntry> links { get; set; }

        readonly Config _config;

        public LinksDbContext(IOptions<Config> config)
        {
            _config = config.Value;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config.connectionString);
        }
    }
}
