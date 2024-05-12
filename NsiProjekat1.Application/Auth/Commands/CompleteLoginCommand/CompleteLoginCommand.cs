﻿using NsiProjekat1.Application.Common.Dto.Auth;
using NsiProjekat1.Application.Common.Interfaces;
using MediatR;

namespace NsiProjekat1.Application.Auth.Commands.CompleteLoginCommand;

public record CompleteLoginCommand(string ValidationToken) : IRequest<CompleteLoginResponseDto>;

public class CompleteLoginHandler(IAuthService authService) : IRequestHandler<CompleteLoginCommand, CompleteLoginResponseDto>
{
    public async Task<CompleteLoginResponseDto> Handle(CompleteLoginCommand request, CancellationToken cancellationToken) => await authService.CompleteLoginAsync(request.ValidationToken);
}
