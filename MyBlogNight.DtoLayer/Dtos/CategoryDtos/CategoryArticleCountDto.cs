using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DtoLayer.Dtos.CategoryDtos
{
    public class CategoryArticleCountDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ArticleCount { get; set; }
    }
}
