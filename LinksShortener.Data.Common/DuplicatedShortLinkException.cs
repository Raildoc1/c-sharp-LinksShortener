namespace LinksShortener.Data.Common
{
    public sealed class DuplicatedShortLinkException : Exception
    {
        public DuplicatedShortLinkException(string shortLink)
            : base("Attempt to insert duplicated short link")
        {
            Data["ShortLink"] = shortLink;
        }
    }
}
