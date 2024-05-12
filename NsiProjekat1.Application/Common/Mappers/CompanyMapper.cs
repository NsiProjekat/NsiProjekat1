using NsiProjekat1.Application.Common.Dto.Company;
using NsiProjekat1.Application.Common.Dto.Product;
using NsiProjekat1.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace NsiProjekat1.Application.Common.Mappers;

[Mapper]
public static partial class CompanyMapper
{
    public static CompanyDetailsDto ToDto(this Company entity)
    {
        var dto = new CompanyDetailsDto(entity.Name,
            entity.Description);
        return dto;
    }
    public static Company FromCreateDtoToEntity(this CompanyCreateDto dto)
    {
        var company = new Company(dto.Name,
            dto.Description);
        return company;
    }public static Company ToCustomDto(this CompanyCreateDto dto)
    {
        var company = new Company(dto.Name, dto.Description);
        
        return company;
    }

}