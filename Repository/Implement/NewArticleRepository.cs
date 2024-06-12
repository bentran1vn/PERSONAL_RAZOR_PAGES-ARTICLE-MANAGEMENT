using BusinessObjects;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class NewArticleRepository(FunewsManagementDbContext context): BaseRepository<NewsArticle>(context), INewsArticleRepository
    {
    }
}
