using Api_Inventario.Data;
using Microsoft.AspNetCore.Mvc;
using Api_Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Inventario;

[ApiController]
[Route("v1/")]
public class ItemController : ControllerBase
{
    [HttpGet("item/")]
    public async Task<IActionResult> GetItem([FromServices] AppDbContext context)
    {
        try
        {
            var items = await context.Items.ToListAsync();
            return Ok(items);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet("item/{id:int}")]
    public async Task<IActionResult> GetByIdItem([FromRoute] int id, [FromServices] AppDbContext context)
    {
        try
        {
            var item = await context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("item/")]
    public async Task<IActionResult> RegisterItem([FromBody] ItemModel item, [FromServices] AppDbContext context) 
    {
       try
        {
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();


            return Created($"/{item.Id}", item);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut("item/{id:int}")]
    public async Task<IActionResult> EditItem([FromRoute] int id, [FromServices] AppDbContext context, [FromBody] ItemModel item)
    {
        try
        {
            var model = await context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            model.Quantidade = item.Quantidade;
            context.Items.Update(model);

            await context.SaveChangesAsync();

            return Ok(model);
        }

        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("item/{id:int}")]
    public async Task<IActionResult> DeleteItem([FromRoute] int id, [FromServices] AppDbContext context)
    {
     try
        {
            var model = await context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            context.Items.Remove(model);
            await context.SaveChangesAsync();


            return Ok(model);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
