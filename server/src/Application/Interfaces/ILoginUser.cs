using server.src.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Any;

public interface ILoginUser
{
    Task<User?> Execute(string email, string password);
}