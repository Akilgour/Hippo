using Hippologamus.Server.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Hippologamus.API.Test.Models
{
    public class DetailLogCommentEditTest
    {
        [Fact]
        public void ErrorMessage_IsSet()
        {
            //arrange
            var model = new DetailLogCommentEdit() { LinkedToDevOps = true };

            //act
            var contex = new ValidationContext(model);
            var result = model.Validate(contex);


            //assert
            Assert.Single(result);
            Assert.Equal("If linked to a dev ops itm, you must provide a devops Id.", result.First().ErrorMessage);
            Assert.Single(result.First().MemberNames);
            Assert.Equal("DevOpsId", result.First().MemberNames.First());

        }

        [Fact]
        public void NoErrorMessage_IsSet()
        {
            //arrange
            var model = new DetailLogCommentEdit() { LinkedToDevOps = true, DevOpsId = "425" };

            //act
            var contex = new ValidationContext(model);
            var result = model.Validate(contex);

            //assert
            Assert.Empty(result);
        }
    }
}
