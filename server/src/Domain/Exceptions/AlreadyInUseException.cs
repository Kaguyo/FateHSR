using System.Security.Cryptography.X509Certificates;

namespace server.src.Domain.Exceptions;

public class AlreadyInUseException() : Exception("Email is already in use."){}