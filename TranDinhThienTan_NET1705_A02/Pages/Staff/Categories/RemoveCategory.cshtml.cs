using BusinessObjects;
using DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranDinhThienTan_NET1705_A02.Utils;

namespace TranDinhThienTan_NET1705_A02.Pages.Staff.Categories;

public class RemoveCategory : PageModel
{
    private readonly CategoryDAO _categoryDao;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemoveCategory(CategoryDAO categoryDao, IHttpContextAccessor httpContextAccessor)
    {
        _categoryDao = categoryDao;
        _httpContextAccessor = httpContextAccessor;
    }

    [BindProperty]
    public Category Category { get; set; } 

    public  IActionResult OnGet(short? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category =  _categoryDao.GetCategoryById((short)id);
        if (category == null)
        {
            return NotFound();
        }
        Category = category;
        return Page();
    }

    public IActionResult OnPostAsync(short? id)
    {
        if (id == null)
        {
            return NotFound();
        }
            
        var account =  _categoryDao.GetCategoryById((short)id);
        if (account != null)
        {
            _categoryDao.Remove(account);
            _httpContextAccessor.HttpContext.Session.WriteHistory("Category", "Remove Category");
        }

        return RedirectToPage("./Index");
    }
}