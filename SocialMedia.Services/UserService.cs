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
            using (var dbSet = new ApplicationDbContext())
            {
                foreach (User user in dbSet.Users)
                    if (user.Id == entity.Id)
                        return false;

                dbSet.Users.Add(entity);
                return dbSet.SaveChanges() == 1;
            }


        }
    }
}
