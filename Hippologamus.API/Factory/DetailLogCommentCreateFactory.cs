using Hippologamus.Domain.Models;
using System;

namespace Hippologamus.API.Factory
{
    public static class DetailLogCommentCreateFactory
    {
        public static DetailLogComment Create(DetailLogComment detailLogComment, int detailLogId)
        {
            detailLogComment.DetailLogId = detailLogId;
            detailLogComment.CreateOn = DateTime.UtcNow;
            detailLogComment.UpdatedOn = DateTime.UtcNow;
            detailLogComment.OpenState = true;
            return detailLogComment;
        }
    }
}