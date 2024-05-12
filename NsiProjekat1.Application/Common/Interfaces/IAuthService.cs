using NsiProjekat1.Application.Common.Dto.Auth;
using NsiProjekat1.Application.Common.Dto.Auth;

namespace NsiProjekat1.Application.Common.Interfaces;

public interface IAuthService
{
    Task<BeginLoginResponseDto> BeginLoginAsync(string emailAddress);
    Task<CompleteLoginResponseDto> CompleteLoginAsync(string token);
}
