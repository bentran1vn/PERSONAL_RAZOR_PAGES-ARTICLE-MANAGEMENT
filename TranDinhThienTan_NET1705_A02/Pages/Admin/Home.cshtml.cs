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
        private readonly SystemAccountDAO _systemAccountDao;

        public IndexModel(SystemAccountDAO systemAccountDao)
        {
            _systemAccountDao = systemAccountDao;
        }

        public IList<SystemAccount> SystemAccount { get;set; } = default!;

        public void OnGet()
        {
            SystemAccount =  _systemAccountDao.GetAllSystemAccounts().ToList();
        }
    }
}
