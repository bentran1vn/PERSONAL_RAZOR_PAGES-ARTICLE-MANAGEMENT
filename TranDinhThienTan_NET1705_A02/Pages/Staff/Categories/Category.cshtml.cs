using DataAccessObjects;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TranDinhThienTan_NET1705_A02.Pages.Staff.Categories;

public class CategoryModel : PageModel
{
    private readonly CategoryDAO _categoryDao;
    
    public CategoryModel(CategoryDAO categoryDao)
    {
        _categoryDao = categoryDao;
    }
    public IList<Category> CategoryList { get;set; } = default!;

    public void OnGet()
    {
        CategoryList =  _categoryDao.GetAllCategories().ToList();
    }
}