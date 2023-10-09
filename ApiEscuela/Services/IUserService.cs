using Domain.Entities;
using ApiEscuela.Dtos;

namespace ApiEscuela.Services;

    public interface IUserService
    {
        Task<string> RegisterAsync(PostEncryptDto registerDto);
    }
