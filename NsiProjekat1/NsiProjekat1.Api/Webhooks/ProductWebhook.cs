using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NsiProjekat1.Api.Auth.Constants;
using NsiProjekat1.Application.Products.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NsiProjekat1.Application.Products.Queries;

namespace NsiProjekat1.Api.Webhooks;

[Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
public class ProductWebhook : BaseWebhook
{
    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] ProductDetailsQuery query) => Ok(await Mediator.Send(query));
    
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete]
    public async Task<IActionResult> Delete(ProductDeleteCommand command) => Ok(await Mediator.Send(command));
}