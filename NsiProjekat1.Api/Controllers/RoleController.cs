using NsiProjekat1.Application.Roles.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NsiProjekat1.Api.Controllers;

public class RoleController : ApiBaseController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> CreateRole(CreateRoleCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
