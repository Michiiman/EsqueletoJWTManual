using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiEscuela.Dtos;
public class StudentDto
{
    public int Id {get; set;}
    public string Name { get; set; }
    public string Lastname { get; set; }
    public int ClassIdFk { get; set; }
    public ClassDto Class { get; set; }
    public UserDto User { get; set; }

}