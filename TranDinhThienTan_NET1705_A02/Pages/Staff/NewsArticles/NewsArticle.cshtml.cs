using DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TranDinhThienTan_NET1705_A02.Pages.Staff;

public class NewsArticle : PageModel
{

    public NewsArticleDao _newsArticleDao;

    public NewsArticle(NewsArticleDao newsArticleDao)
    {
        _newsArticleDao = newsArticleDao;
    }
    
    [BindProperty]
    public IList<BusinessObjects.NewsArticle> NewsArticlesList { set; get; }
    public void OnGet()
    {
        NewsArticlesList = _newsArticleDao.GetAllNewsArticles().ToList();
    }
}