using NsiProjekat1.Api.Auth.Constants;
using NsiProjekat1.Application.Products.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NsiProjekat1.Application.Companies.Commands;
using NsiProjekat1.Application.Companies.Queries;

namespace NsiProjekat1.Api.Webhooks;

[Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
public class CompanyWebhook : BaseWebhook
{
    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] CompanyDetailsQuery query) => Ok(await Mediator.Send(query));
    
    [HttpPost]
    public async Task<IActionResult> Create(CompanyCreateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete]
    public async Task<IActionResult> Delete(CompanyDeleteCommand command) => Ok(await Mediator.Send(command));
}