namespace Hippologamus.Shared.DTO
{
    public class DetailLogCommentUpdate
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool LinkedToDevOps { get; set; }
        public string DevOpsId { get; set; }
        public int DetailLogId { get; set; }
        public bool OpenState { get; set; }
    }
}
