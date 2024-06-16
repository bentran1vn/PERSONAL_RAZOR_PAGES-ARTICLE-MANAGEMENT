using BusinessObjects;
using DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TranDinhThienTan_NET1705_A02.Pages.Staff.NewsArticles;

public class EditNewsArticle : PageModel
{
    private readonly NewsArticleDao _newsArticleDao;
    private readonly CategoryDAO _categoryDao;
    private readonly TagDAO _tagDAO;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EditNewsArticle(CategoryDAO categoryDao, TagDAO tagDAO, NewsArticleDao newsArticleDao, IHttpContextAccessor httpContextAccessor)
    {
        _newsArticleDao = newsArticleDao;
        _categoryDao = categoryDao;
        _tagDAO = tagDAO;
        _httpContextAccessor = httpContextAccessor;
    }
    
    [BindProperty]
    public BusinessObjects.NewsArticle NewsArticle { get; set; }
    
    [BindProperty]
    public IList<Category> Categories { get; set; }
    
    [BindProperty]
    public IList<Tag> Tags { get; set; }
    
    public IActionResult OnGet(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var newsArticle =  _newsArticleDao.GetNewsArticleById(id);
        Categories = _categoryDao.GetAllCategories().ToList();
        Tags = _tagDAO.GetAllTags().ToList();
        
        if (newsArticle == null)
        {
            return NotFound();
        }
        NewsArticle = newsArticle;
        return Page();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        try
        {
            var newsArticle =  _newsArticleDao.GetNewsArticleById(NewsArticle.NewsArticleId);
            newsArticle.CategoryId = NewsArticle.CategoryId;
            newsArticle.NewsStatus = NewsArticle.NewsStatus;
            _newsArticleDao.SaveChange();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return RedirectToPage("./NewsArticle");
    }
}