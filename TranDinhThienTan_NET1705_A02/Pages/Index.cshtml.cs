using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;

namespace TranDinhThienTan_NET1705_A02.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CategoryDAO _categoryDAO;

        public IndexModel(CategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }

        public IList<Category> Category { get;set; } = default!;

        public void OnGetAsync()
        {
            Category =  _categoryDAO.GetAllCategories().ToList();
        }
    }
}
