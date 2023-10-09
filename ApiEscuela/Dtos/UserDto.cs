
namespace ApiEscuela.Dtos;
public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleIdFk { get; set; }
    public RoleDto Role { get; set; }

}