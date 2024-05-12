using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Application.Products.Commands;
using NsiProjekat1.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace NsiProjekat1.Api.Controllers;

public class ProductController(INsiProjekat1DbContext dbContext) : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] ProductDetailsQuery query) => Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpPost("test-create")]
    public async Task<IActionResult> TestCreate(ProductTestCreateDto dto)
    {
        var command = dto.Json.Deserialize<ProductCreateCommand>(SerializerExtensions.SettingsWebOptions);
        
        return Ok(await Mediator.Send(command!));
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(ProductDeleteCommand command) => Ok(await Mediator.Send(command));
}