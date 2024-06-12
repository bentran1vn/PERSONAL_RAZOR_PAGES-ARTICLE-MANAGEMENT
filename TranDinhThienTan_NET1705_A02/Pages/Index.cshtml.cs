using System.ComponentModel.DataAnnotations;
using BusinessObjects;
using DataAccessObjects;
using DataAccessObjects.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        // Redirect if user is already authenticated
        var currentUser = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<SystemAccount>("currentUser");
        if (currentUser != null)
        {
            return RedirectToPage("/Home");
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
                _httpContextAccessor.HttpContext.Session.SetObjectAsJson("currentUser", result);
                return LocalRedirect(returnUrl);
            }
            else
            {
                Console.WriteLine("huhu");
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