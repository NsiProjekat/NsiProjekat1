using NsiProjekat1.Application.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NsiProjekat1.Api.Controllers;

public class UserController : ApiBaseController
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
