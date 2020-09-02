using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
   public class CommentService
    {
        private readonly Guid _userId;
        public CommentService (Guid userId)
        {
            _userId = userId;
        }
        
        public bool CreateComment (CommentCreate model)
        {
            var entity = 
                new Comment()
            {
                    CommentPostId = model.PostId,
                Text = model.CommentText
            };

            using (var dbSet = new ApplicationDbContext())
            {
                entity.Author = dbSet.Users.Where(e => e.Id == _userId).First();
                dbSet.Comments.Add(entity);
                return dbSet.SaveChanges() == 2;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var dbSet = new ApplicationDbContext())
            {
                var query =
                    dbSet
                    .Comments
                    .Where(e => e.Author.Id == _userId)
                    .Select(e =>
                   new CommentListItem
                   {
                       PostId = e.CommentPostId,
                       Text = e.Text,
                   }
                    );
                return query.ToArray();
            }
        }
    }
}
