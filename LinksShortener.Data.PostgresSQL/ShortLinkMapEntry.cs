using System.ComponentModel.DataAnnotations;

namespace LinksShortener.Data.PostgresSQL
{
    public record ShortLinkMapEntry
    {
        [Key] public string @short { get; set; }
        public string @long { get; set; }
    }
}
