using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using DataAccessObjects;
using Humanizer;

namespace TranDinhThienTan_NET1705_A02.Pages
{
    public class CreateModel : PageModel
    {
        private readonly SystemAccountDAO _systemAccountDao;
        
        [BindProperty]
        public SystemAccount SystemAccount { get; set; }
        
        public CreateModel(SystemAccountDAO systemAccountDao)
        {
            _systemAccountDao = systemAccountDao;
        }

        public IActionResult OnGet()
        {
            SystemAccount = new SystemAccount()
            {
                AccountId = short.Parse(_systemAccountDao.GetId().ToString())
            };
            return Page();
        }

        
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _systemAccountDao.Add(SystemAccount);
            return RedirectToPage("./Index");
        }
    }
}
