﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.EntityLayer.Concrete
{
    internal class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
        public DateTime CreateDate { get; set; }
        public string CoverImageUrl { get; set; }
        public string MainImageUrl { get; set; }

    }
}
