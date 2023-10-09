namespace Domain.Entities;
public class Subject:BaseEntity
{
    public string Name { get; set; }
    public int TeacherIdFk { get; set; }
    public Teacher Teacher { get; set; }
    public int StudentIdFk { get; set; }
    public Student Student{ get; set; }
    public ICollection<Grade> Grades { get; set; }

}