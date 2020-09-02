using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                Text = model.CommentText,
                CommentId = model.CommentId,
                CommentPostId = model.PostId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                entity.Author = ctx.Users.Where(e => e.Id == _userId).First();
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 2;
            }
        } 

        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies.Single(e => e.CommentId == id);

                return new ReplyDetail
                {
                    PostId = entity.CommentPostId,
                    CommentId = entity.CommentId,
                    ReplyDetailId = entity.CommentId,
                    Text = entity.Text,
                    ReplyComment = entity.ReplyComment
                };
            }
        }
    }
}
