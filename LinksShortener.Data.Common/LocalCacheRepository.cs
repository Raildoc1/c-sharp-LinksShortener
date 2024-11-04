namespace LinksShortener.Data.Common
{
    public class LocalCacheRepository : IRepository
    {
        readonly Dictionary<string, string> _linksMap;
        readonly Dictionary<string, string> _linksToAdd;

        public LocalCacheRepository()
        {
            _linksMap = new Dictionary<string, string>();
            _linksToAdd = new Dictionary<string, string>();
        }

        public void Add(string shortLink, string link)
        {
            if (_linksMap.ContainsKey(shortLink)
             || !_linksToAdd.TryAdd(shortLink, link))
            {
                throw new DuplicatedShortLinkException(shortLink);
            }
        }

        public string Find(string shortLink)
        {
            if (!_linksMap.TryGetValue(shortLink, out string? link))
            {
                throw new NoSuchShortLinkException(shortLink);
            }

            return link;
        }

        public void ApplyChanges()
        {
            foreach ((string shortLink, string link) in _linksToAdd)
            {
                _linksMap.Add(shortLink, link);
            }

            _linksToAdd.Clear();
        }
    }
}
