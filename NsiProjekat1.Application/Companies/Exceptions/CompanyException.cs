using NsiProjekat1.Application.Common.Exceptions;

namespace NsiProjekat1.Application.Companies.Exceptions;

public class CompanyException : BaseException
{
    public CompanyException(string message, object? additionalData = null) : base(message, additionalData)
    {
        
    }
}