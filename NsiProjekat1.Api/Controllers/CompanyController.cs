using NsiProjekat1.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NsiProjekat1.Application.Companies.Commands;
using NsiProjekat1.Application.Companies.Queries;

namespace NsiProjekat1.Api.Controllers;

public class CompanyController(INsiProjekat1DbContext dbContext) : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] CompanyDetailsQuery query) => Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> Create(CompanyCreateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete]
    public async Task<IActionResult> Delete(CompanyDeleteCommand command) => Ok(await Mediator.Send(command));
}