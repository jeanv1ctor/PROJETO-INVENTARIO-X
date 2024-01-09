using Api_Inventario.Data;
using Api_Inventario.Services;
using Api_Inventario.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Inventario.Controllers;


[ApiController]
[Route("v1/accounts/")]
public class AccountController : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(
       [FromBody]RegisterViewModel model, [FromServices] AppDbContext context )
    {
 
        if(!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        var user = new UserModel
        {
            Nome = model.Nome,
            Email = model.Email,
            PasswordHash = model.PasswordHash
        };

        try
        {          
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return Created($"/{user.Id}", user);
            
        }

        catch (DbUpdateException ex)
        {
            return BadRequest(ex.Message);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login( [FromBody] LoginViewModel model, [FromServices] AppDbContext context,
        [FromServices] TokenService tokenService)
    {
        if(ModelState.IsValid)
        {
            return BadRequest();
        }

    }
}
