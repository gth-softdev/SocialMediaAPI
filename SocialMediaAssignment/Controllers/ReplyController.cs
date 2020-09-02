using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SocialMediaAssignment.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;

        }

        [HttpPost]
        public IHttpActionResult PostReplyToComment(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateReplyService();
            if (!service.CreateReply(reply))
                return InternalServerError();
            return Ok("Reply Successfully added.");
        }
        [HttpGet]
        public IHttpActionResult GetReplyById (int id)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyById(id);
            return Ok(reply);
        }
    }
}