

namespace ApiEscuela.Dtos;

public class PostEncryptDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleIdFk { get; set; }
    
}
