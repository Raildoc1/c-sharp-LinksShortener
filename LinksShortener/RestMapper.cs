namespace LinksShortener.Interface
{
    public record ShortenRequestData(string link);

    public static class RestMapper
    {
        public static void Map(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder
               .MapGet(
                    "/open/{shortLink}",
                    (string shortLink, Logic.Shortener.Controller shortener, HttpContext httpContext) =>
                    {
                        string fullLink = shortener.GetFullLink(shortLink);
                        httpContext.Response.Redirect(fullLink);
                    }
                )
               .WithName("OpenShortLink")
               .WithOpenApi();

            endpointRouteBuilder
               .MapPost("/shorten/", (ShortenRequestData requestData, Logic.Shortener.Controller shortener) => shortener.Shorten(requestData.link))
               .WithName("ShortenLink")
               .WithOpenApi();
        }
    }
}
