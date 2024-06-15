﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface INewsArticleRepository : IBaseRepository<NewsArticle>
    {
        IEnumerable<NewsArticle> GetAllNewsArticlesIncludes();
        NewsArticle? GetNewsArticlesByIdIncludes(string id);
    }
}
