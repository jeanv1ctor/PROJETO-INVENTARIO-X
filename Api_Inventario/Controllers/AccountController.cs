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
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        var user = await context.Users.AsNoTracking().Include(x => x.Roles).FirstOrDefaultAsync(x => x.Email == model.Email);

        if(user == null)//validando email
        {
            return StatusCode(401, "usuario ou senha invalidos");
        }

        var password = await context.Users.AsNoTracking().Include(x => x.Roles).FirstOrDefaultAsync(x => x.PasswordHash == model.PasswordHash);

        if (password.PasswordHash != model.PasswordHash)//validando senha
        {
            return StatusCode(401, "usuario ou senha invalidos");
        }

        try
        {
            var token = tokenService.GenerateToken(user);
            return Ok(token);
        }
        catch(Exception ex)
        {
            return StatusCode(500, "falha interna");
        }
    }
}
