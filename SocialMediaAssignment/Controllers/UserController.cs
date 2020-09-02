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
        public class UserController : ApiController
        {
            private UserService CreateUserService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var userEmail = User.Identity.GetUserName();
                var UserService = new UserService(userId, userEmail);
                return UserService;
            }

            [HttpPost]
            public IHttpActionResult CreateUser(UserCreate user)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateUserService();

                if (!service.CreateUser(user))
                    return InternalServerError();

                return Ok("Account successfully created.");
            }

        }
    
}