using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using ApiEscuela.Dtos;
using Domain.Entities;
using Domain.Interfaces;



namespace ApiEscuela.Services;

public class UserService : IUserService
{
    public readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<string> RegisterAsync(PostEncryptDto registerDto)
    {
        var user = new User
        {
            Email = registerDto.Email,
            RoleIdFk = registerDto.RoleIdFk

        };

        Encriptacion encrip = new Encriptacion();
        user.Password = encrip.GetSHA256(registerDto.Password); //Encriptamos contraseña

        try
        {
            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveAsync();

            return $"User has been registered successfully";
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            return $"Error: {message}";
        }
    }

}

