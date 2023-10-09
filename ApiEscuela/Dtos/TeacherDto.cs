

namespace ApiEscuela.Dtos;
public class TeacherDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public UserDto User { get; set; }
}