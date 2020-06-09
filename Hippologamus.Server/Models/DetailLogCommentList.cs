﻿using System;

namespace Hippologamus.Server.Models
{
    public class DetailLogCommentList
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool LinkedToDevOps { get; set; }
        public string DevOpsId { get; set; }
        public int DetailLogId { get; set; }
        public bool OpenState { get; set; }
        public string CreateadBy { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}