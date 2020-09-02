using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyDetail : CommentListItem
    {
        //Reply structure to allow comment inheritance in Comment/Reply Service
        public int ReplyDetailId { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }

        public virtual Comment ReplyComment { get; set; }
    }
}
