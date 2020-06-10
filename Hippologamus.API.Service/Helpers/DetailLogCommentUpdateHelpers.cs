using Hippologamus.Domain.Models;
using System;

namespace Hippologamus.API.Service.Helpers
{
    public class DetailLogCommentUpdateHelpers
    {
        public static void Update(DetailLogComment detailLogComment)
        {
            detailLogComment.UpdatedOn = DateTime.UtcNow;
        }
    }
}
