using System.Security.Cryptography.X509Certificates;

namespace server.src.Domain.Exceptions;

public class AlreadyInUseException() : Exception("Email or Username is already in use."){}