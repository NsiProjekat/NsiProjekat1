using NsiProjekat1.Api.Auth.Constants;
using NsiProjekat1.Api.Auth.Options;
using NsiProjekat1.Api.Auth.Schemes;

namespace NsiProjekat1.Api.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddNsiProjekat1SdkAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddScheme<HeaderBasicAuthenticationSchemeOptions, HeaderBasicAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
                schemeOptions => configuration.GetSection("Auth:Header")
                    .Bind(schemeOptions));
        
        // services.AddAuthentication()
        //     .AddScheme<JwtAuthenticationSchemeOptions, JwtAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
        //         schemeOptions => configuration.GetSection("Auth:Header")
        //             .Bind(schemeOptions));

        return services;
    }
}