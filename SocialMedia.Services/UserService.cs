using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class UserService
    {
        private readonly Guid _userId;
        private readonly string _email;

        public UserService(Guid userId, string email)
        {
            _userId = userId;
            _email = email;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    Id = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = _email
                };
            using (var ctx = new ApplicationDbContext())
            {
                foreach (User user in ctx.Users)
                    if (user.Id == entity.Id)
                        return false;

                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
    }
}
