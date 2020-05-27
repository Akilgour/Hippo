namespace Hippologamus.DTO.DTO
{
    public class RootLink
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }

        public RootLink(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }

        public RootLink()
        {
        }
    }
}