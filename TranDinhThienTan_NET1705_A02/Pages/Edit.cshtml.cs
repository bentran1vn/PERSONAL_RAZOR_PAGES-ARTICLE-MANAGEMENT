using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;

namespace TranDinhThienTan_NET1705_A02.Pages
{
    public class EditModel : PageModel
    {
        private readonly SystemAccountDAO _systemAccountDao;

        public EditModel(SystemAccountDAO systemAccountDao)
        {
            _systemAccountDao = systemAccountDao;
        }

        [BindProperty]
        public SystemAccount SystemAccount { get; set; }

        public IActionResult OnGet(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account =  _systemAccountDao.GetSystemAccountById((short)id);
            if (account == null)
            {
                return NotFound();
            }
            SystemAccount = account;
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
                _systemAccountDao.Update(SystemAccount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}
