﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Reply : Comment
    {
        public Comment ReplyComment { get; set; }

    }
}
