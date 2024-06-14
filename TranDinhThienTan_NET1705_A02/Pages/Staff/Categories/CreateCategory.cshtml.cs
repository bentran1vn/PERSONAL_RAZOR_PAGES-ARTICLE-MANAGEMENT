using BusinessObjects;
using DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranDinhThienTan_NET1705_A02.Utils;

namespace TranDinhThienTan_NET1705_A02.Pages.Staff.Categories;

public class CreateCategory : PageModel
{
    private readonly CategoryDAO _categoryDao;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateCategory(CategoryDAO categoryDao, IHttpContextAccessor httpContextAccessor)
    {
        _categoryDao = categoryDao;
        _httpContextAccessor = httpContextAccessor;
    }
    
    [BindProperty]
    public Category Category { get; set; }
    
    public IActionResult OnGet()
    {
        return Page();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        Console.WriteLine(Category);
        _categoryDao.Add(Category);
        _httpContextAccessor.HttpContext.Session.WriteHistory("Category", "Add New Category");
        return RedirectToPage("./Categories/Category");
    }
}