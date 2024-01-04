using Api_Inventario.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Inventario.Controllers;

[ApiController]
[Route("v1/")]
public class AccountController : ControllerBase
{
    /*
    private readonly TokenService _tokenService;
    public AccountController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }
    */

    [HttpPost("login")]
    public IActionResult Login([FromServices]TokenService _tokenService)
    {
        var token = _tokenService.GenerateToken(null);

        return Ok(token);
    }
}
