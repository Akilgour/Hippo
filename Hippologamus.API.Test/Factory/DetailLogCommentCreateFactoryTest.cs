using Hippologamus.API.Factory;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using System;
using Xunit;

namespace Hippologamus.API.Test.Factory
{
    public class DetailLogCommentCreateFactoryTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(99)]
        public void DetailLogId_IsSet(int detailLogId)
        {
            //arrange
            var detailLogComment = new DetailLogComment();

            //act
            var value = DetailLogCommentCreateFactory.Create(detailLogComment, detailLogId);
            //assert

            Assert.Equal(detailLogId, value.DetailLogId);
        }

        [Fact]
        public void CreateOn_IsSet()
        {
            //arrange
            var detailLogComment = new DetailLogComment();
            var detailLogId = 1;
            var now = DateTime.UtcNow.Date;
           
            //act
            var value = DetailLogCommentCreateFactory.Create(detailLogComment, detailLogId);
           
            //assert
            Assert.Equal(now, value.CreateOn.Date);
            Assert.Equal(now, value.UpdatedOn.Date);
        }

        [Fact]
        public void OpenState_IsSet()
        {
            //arrange
            var detailLogComment = new DetailLogComment();
            var detailLogId = 1;

            //act
            var value = DetailLogCommentCreateFactory.Create(detailLogComment, detailLogId);

            //assert
            Assert.True(value.OpenState);
        }
    }
}