namespace Hippologamus.Server.Models
{
    public class PerfLogDisplayCollection
    {
        public PerfLog[] Value { get; set; }
        public Links[] Links { get; set; }
        public PaginationHeader PaginationHeader { get; set; }
    }
}