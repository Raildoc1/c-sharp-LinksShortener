using LinksShortener.Data.Common;
using Microsoft.Extensions.Options;

namespace LinksShortener.Logic.Shortener
{
    public class Controller
    {
        readonly IRepository _repository;
        readonly Config _config;
        readonly Random _random;

        public Controller(IRepository repository, Random random, IOptions<Config> config)
        {
            _repository = repository;
            _random = random;
            _config = config.Value;
        }

        public string Shorten(string link)
        {
            string shortLink = GenerateShortLink();

            _repository.Add(shortLink, link);
            _repository.ApplyChanges();

            return shortLink;
        }

        public string GetFullLink(string shortLink)
        {
            return _repository.Find(shortLink);
        }

        string GenerateShortLink()
        {
            return new string(
                Enumerable
                   .Repeat(_config.charset, _config.length)
                   .Select(s => s[_random.Next(s.Length)])
                   .ToArray()
            );
        }
    }
}
