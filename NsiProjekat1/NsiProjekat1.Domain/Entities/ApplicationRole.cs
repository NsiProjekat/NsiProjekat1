using Microsoft.AspNetCore.Identity;

namespace NsiProjekat1.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public IList<ApplicationUserRole> UserRoles { get; set; }
}