using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyCreate : CommentCreate
    {
        //Create(Post) a reply to a comment, grab initial comment to reply to
        [Required]
        public int CommentId { get; set; }
    }
}
