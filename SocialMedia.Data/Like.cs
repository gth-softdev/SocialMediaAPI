using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post LikedPost { get; set; }

        [Required]
        public Guid LikerId { get; set; }

        public virtual User Liker { get; set; }
    }
}
