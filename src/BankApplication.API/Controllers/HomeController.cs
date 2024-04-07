using Microsoft.AspNetCore.Mvc;

namespace BankApplication.API;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public async Task<string> Home() 
    {
        return "Backend em docker";
    }
}
