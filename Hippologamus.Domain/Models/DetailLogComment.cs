namespace Hippologamus.Domain.Models
{
    public class DetailLogComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int DetailLogId { get; set; }
    }
}