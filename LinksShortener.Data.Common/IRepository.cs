namespace LinksShortener.Data.Common
{
    public interface IRepository
    {
        void Add(string shortLink, string link);
        string Find(string shortLink);
        void ApplyChanges();
    }
}
