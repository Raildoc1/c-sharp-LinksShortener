namespace LinksShortener.Logic.Shortener
{
    public class Config
    {
        public string charset { get; init; }
        public int length { get; init; }

        public bool Validate()
        {
            if (length < 1)
            {
                throw new Exception("length must be greater than 0");
            }

            if (charset.Length < 1)
            {
                throw new Exception("charset cannot be empty");
            }

            return true;
        }
    }
}
