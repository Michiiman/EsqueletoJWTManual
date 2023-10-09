

namespace ApiEscuela.Dtos;
public class SubjectDto
{
    public int Id {get; set;}
    public string Name { get; set; }
    public int TeacherIdFk { get; set; }
    public TeacherDto Teacher { get; set; }
    public int StudentIdFk { get; set; }
    public StudentDto Student{ get; set; }

}