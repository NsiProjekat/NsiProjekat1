﻿using NsiProjekat1.Application.Common.Interfaces;
using NsiProjekat1.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace NsiProjekat1.Infrastructure.Identity;

public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
{

    public async Task CreateRoleAsync(string role)
    {
        var alreadyExist = await roleManager.RoleExistsAsync(role);

        if (!alreadyExist)
        {
            await roleManager.CreateAsync(new ApplicationRole
            {
                Name = role,
                NormalizedName = role.Normalize()
            });
        }
    }
}
