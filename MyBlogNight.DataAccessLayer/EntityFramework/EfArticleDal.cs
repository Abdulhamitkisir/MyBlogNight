using Microsoft.EntityFrameworkCore;
using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using MyBlogNight.DataAccessLayer.Repositories;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        public EfArticleDal(BlogContext context) : base(context)
        {
        }

        public List<Article> ArticleListWithCategory()
        {
            var context = new BlogContext();
            var values = context.Articles.Include(x => x.Category).ToList();
            return values;
        }

        public List<Article> ArticleListWithCategoryAndAppUser()
        {
            var context = new BlogContext();
            var values = context.Articles.Include(x => x.Category).Include(x => x.AppUser).ToList();
            return values;
        }

        public Article ArticleListWithCategoryAndAppUserByArticleId(int id)
        {
            var context = new BlogContext();
            var values = context.Articles.Where(x => x.ArticleId == id).Include(y => y.Category).Include(z => z.AppUser).FirstOrDefault();
            return values;
        }

        public void ArticleViewCountIncrease(int id)
        {
            var contex = new BlogContext();
            var updateValue = contex.Articles.Find(id);
            updateValue.ArticleViewCount += 1;
            contex.SaveChanges();
        }

        public List<Article> GetArticlesByAppUserID(int id)
        {
            var context = new BlogContext();
            var values = context.Articles.Where(x => x.AppUserID == id).Include(y => y.Category).ToList();
            return values;
        }
        public Article GetLastArticle()
        {
            var context = new BlogContext();
            return context.Articles.OrderByDescending(x => x.ArticleId).Take(1).FirstOrDefault();
        }
        public Article GetArticleDetails(int id)
        {
            var context = new BlogContext();
            return context.Articles.Include(x => x.Category).Include(y => y.AppUser).Where(z => z.ArticleId == id).FirstOrDefault();
        }


    }
}
