using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentCreate
    {
        //Create(post) a comment on a post, use PostId to find Post and create comment text
        [Required]
        public int PostId { get; set; }

        [Required]
        [MaxLength(6000)]
        public string CommentText { get; set; }
    }
}
