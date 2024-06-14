using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranDinhThienTan_NET1705_A02.Utils;

namespace TranDinhThienTan_NET1705_A02.Pages.Staff.Histories;

public class HistoryModel : PageModel
{
    
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HistoryModel(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [BindProperty] public IList<History> HistoryList { get; set; } = new List<History>();
    
    public void OnGet()
    {
        HistoryList = _httpContextAccessor.HttpContext.Session.GetList<History>("History");
    }
}