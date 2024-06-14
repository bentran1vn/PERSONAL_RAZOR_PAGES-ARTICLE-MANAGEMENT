using System.ComponentModel.DataAnnotations;
using BusinessObjects;
using DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranDinhThienTan_NET1705_A02.Utils;

namespace TranDinhThienTan_NET1705_A02.Pages;

public class Index : PageModel
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    private readonly SystemAccountDAO _systemAccountDao;

    public Index(SystemAccountDAO systemAccountDao, IHttpContextAccessor httpContextAccessor)
    {
        _systemAccountDao = systemAccountDao;
        _httpContextAccessor = httpContextAccessor;
    }
    
    [BindProperty]
    public InputModel Input { get; set; }
    public IActionResult OnGet()
    {
        var currentUser = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<SystemAccount>("currentUser");
        if (currentUser != null)
        {
            if (currentUser.AccountRole == 1)
            {
                return RedirectToPage("/Staff/Categories/Category");
            }
            else
            {
                return RedirectToPage("/Admin/Home");
            }
            return RedirectToPage("/Admin/Home");
        }
        return Page();
    }
    
    public IActionResult OnPost(string returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        if (ModelState.IsValid)
        {
            var result = _systemAccountDao.Login(Input.Email, Input.Password);
            if (result != null)
            {
                if (_httpContextAccessor.HttpContext != null)
                {
                    _httpContextAccessor.HttpContext.Session.SetObjectAsJson("currentUser", result);
                    _httpContextAccessor.HttpContext.Session.SetList("History", new List<History>());
                }

                return LocalRedirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }

    public class InputModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}