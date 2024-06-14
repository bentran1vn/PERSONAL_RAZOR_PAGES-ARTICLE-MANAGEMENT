using BusinessObjects;
using DataAccessObjects.Utils;
using Microsoft.AspNetCore.Mvc;

namespace TranDinhThienTan_NET1705_A02.Controllers;
[Route("authenticate")]
public class AuthenticateController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public AuthenticateController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        _httpContextAccessor.HttpContext.Session.SetObjectAsJson("currentUser", null);
        return Ok();
    }
}