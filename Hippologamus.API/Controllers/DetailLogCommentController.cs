using Hippo.Serilog.Attributes;
using Hippologamus.API.Manager.Interface;
using Hippologamus.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hippologamus.API.Controllers
{
    [Route("api/[controller]/{detailLogId}")]
    [ApiController]
    public class DetailLogCommentController : ControllerBase
    {
        private readonly IDetailLogCommentManager _detailLogCommentManager;

        public DetailLogCommentController(IDetailLogCommentManager detailLogCommentManager)
        {
            _detailLogCommentManager = detailLogCommentManager ?? throw new ArgumentNullException(nameof(detailLogCommentManager));
        }

        [HttpPost]
        [LogUsage("Post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(int detailLogId, DetailLogCommentCreate detailLogCommentCreate)
        {
            if (!await _detailLogCommentManager.AnyDetailLog(detailLogId))
            {
                return NotFound();
            }
            await _detailLogCommentManager.CreateDetailLogComent(detailLogCommentCreate, detailLogId);
            return Ok();
        }
    }
}