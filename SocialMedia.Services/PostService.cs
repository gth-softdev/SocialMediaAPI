using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    
                    Id = model.PostId,
                    Title = model.Title,
                    Text = model.Text,
                };
            using (var ctx = new ApplicationDbContext())
            {
                entity.Author = ctx.Users.Where(e => e.Id == _userId).First();
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 2;
            }
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.Author.Id == _userId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.Id,
                                    Title = e.Title,

                                }
                        );
                return query.ToArray();
            }
        }
        public Post GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == id);
                return
                    new Post
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text,
                        //CreatedUtc = entity.CreatedUtc,
                        //ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}

