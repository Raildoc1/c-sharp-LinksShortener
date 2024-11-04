namespace LinksShortener.Data.Common
{
    public sealed class NoSuchShortLinkException : Exception
    {
        public NoSuchShortLinkException(string shortLink)
            : base("No such short link")
        {
            Data["ShortLink"] = shortLink;
        }
    }
}
