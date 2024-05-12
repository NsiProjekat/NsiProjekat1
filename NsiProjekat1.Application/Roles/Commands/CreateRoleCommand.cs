using NsiProjekat1.Application.Common.Interfaces;
using MediatR;

namespace NsiProjekat1.Application.Roles.Commands;

public record CreateRoleCommand(string Role) : IRequest;

public class CreateRoleCommandHandler(IRoleService roleService) : IRequestHandler<CreateRoleCommand>
{
    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken) => await roleService.CreateRoleAsync(request.Role);
}
