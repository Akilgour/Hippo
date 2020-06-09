using System;

namespace Hippologamus.Server.Models
{
    public class DetailLogCommentList
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool LinkedToDevOps { get; set; }
        public string DevOpsId { get; set; }
        public string OpenStateDisplay { get; set; }
        public string CreateadBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
    }
}