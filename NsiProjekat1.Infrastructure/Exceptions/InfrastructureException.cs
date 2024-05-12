using NsiProjekat1.Application.Common.Exceptions;

namespace NsiProjekat1.Infrastructure.Exceptions;

public class InfrastructureException(string message, object? additionalData = null) : BaseException(message,
    additionalData);
