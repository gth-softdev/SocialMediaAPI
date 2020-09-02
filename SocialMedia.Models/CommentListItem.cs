using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentListItem
    {
        //Get Post Comments, use PostId to find Post, text to stand for comment word content
        [Display(Name = "Comment ID")]
        public int PostId { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}
