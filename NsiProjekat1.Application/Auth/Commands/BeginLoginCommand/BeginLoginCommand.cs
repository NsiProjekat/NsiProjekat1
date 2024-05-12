﻿using NsiProjekat1.Application.Common.Dto.Auth;
using NsiProjekat1.Application.Common.Interfaces;
using MediatR;

namespace NsiProjekat1.Application.Auth.Commands.BeginLoginCommand;

public record BeginLoginCommand(string EmailAddress) : IRequest<BeginLoginResponseDto>;

public class BeginLoginHandler(IAuthService authService) : IRequestHandler<BeginLoginCommand, BeginLoginResponseDto>
{
    public async Task<BeginLoginResponseDto> Handle(BeginLoginCommand request, CancellationToken cancellationToken) => await authService.BeginLoginAsync(request.EmailAddress);
}
