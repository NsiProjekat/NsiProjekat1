using Microsoft.AspNetCore.Identity;

namespace NsiProjekat1.Infrastructure.Auth.Options;

public class PasswordlessLoginTokenProviderOptions : DataProtectionTokenProviderOptions
{
    public PasswordlessLoginTokenProviderOptions()
    {
        Name = "PasswordlessLoginTokenProvider";
        TokenLifespan = TimeSpan.FromMinutes(15);
    }
}
