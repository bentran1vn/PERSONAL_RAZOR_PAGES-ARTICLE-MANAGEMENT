using BusinessObjects;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Implement
{
    public class NewArticleRepository(FunewsManagementDbContext context): BaseRepository<NewsArticle>(context), INewsArticleRepository
    {
        public IEnumerable<NewsArticle> GetAllNewsArticlesIncludes()
        {
            return context.Set<NewsArticle>()
                .Include(x => x.Category)
                .Include(x => x.CreatedBy)
                .Include(x => x.NewsTags)
                    .ThenInclude(x => x.Tag)
                .AsNoTracking();
        }
        
        public NewsArticle? GetNewsArticlesByIdIncludes(string id)
        {
            return context.Set<NewsArticle>()
                .Include(x => x.Category)
                .Include(x => x.CreatedBy)
                .Include(x => x.NewsTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.NewsArticleId.Equals(id));
        }
    }
}
