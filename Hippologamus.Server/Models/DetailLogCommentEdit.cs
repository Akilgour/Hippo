namespace Hippologamus.Server.Models
{
    public class DetailLogCommentEdit
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool LinkedToDevOps { get; set; }
        public string DevOpsId { get; set; }
        public string CreateadBy { get; set; }
    }
}