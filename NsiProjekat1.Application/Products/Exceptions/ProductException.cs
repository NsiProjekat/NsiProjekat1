using NsiProjekat1.Application.Common.Exceptions;

namespace NsiProjekat1.Application.Products.Exceptions;

public class ProductException : BaseException
{
    public ProductException(string message, object? additionalData = null) : base(message,
        additionalData)
    {
    }
}