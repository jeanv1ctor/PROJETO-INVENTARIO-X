using Api_Inventario.Data;
using Microsoft.AspNetCore.Mvc;
using Api_Inventario.Models;

namespace Api_Inventario;

[ApiController]
public class ItemController : ControllerBase
{
    [HttpGet("item/")]
    public IActionResult Get([FromServices] AppDbContext context)
    {
       
       return Ok(context.Items.ToList());
    }

    [HttpGet("item/{id:int}")]
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var item = context.Items.FirstOrDefault(x => x.Id == id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost("item/")]
    public IActionResult Post([FromBody] ItemModel item, [FromServices] AppDbContext context) 
    {
        context.Items.Add(item);
        context.SaveChanges();


        return Created($"/{item.Id}", item);
    }


}
