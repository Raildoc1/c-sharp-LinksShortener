using LinksShortener.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LinksShortener.Data.PostgresSQL
{
    public class DbRepository : IRepository
    {
        readonly LinksDbContext _linksDbContext;
        readonly DbSet<ShortLinkMapEntry> _linkMapEntries;

        public DbRepository(LinksDbContext linksDbContext)
        {
            _linksDbContext = linksDbContext;
            _linkMapEntries = linksDbContext.Set<ShortLinkMapEntry>();
        }

        public void Add(string shortLink, string link)
        {
            _linkMapEntries.Add(
                new ShortLinkMapEntry
                {
                    @short = shortLink,
                    @long = link
                }
            );
        }

        public string Find(string shortLink)
        {
            return _linkMapEntries.Find(shortLink)
                  ?.@long
             ?? throw new NoSuchShortLinkException(shortLink);
        }

        public void ApplyChanges()
        {
            _linksDbContext.SaveChanges();
        }
    }
}
