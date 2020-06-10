using Hippologamus.API.Service.Helpers;
using Hippologamus.Domain.Models;
using System;
using Xunit;

namespace Hippologamus.API.Service.Test.Helpers
{
    public class DetailLogCommentUpdateHelpersTest
    {
        [Fact]
        public void UpdatedOn_IsSet()
        {
            //arrange
            var detailLogComment = new DetailLogComment();
            var now = DateTime.UtcNow.Date;
            //act
            DetailLogCommentUpdateHelpers.Update(detailLogComment);
            //assert
            Assert.Equal(now, detailLogComment.UpdatedOn.Date);
        }
    }
}
