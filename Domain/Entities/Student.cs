using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Student:BaseEntity
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public int ClassIdFk { get; set; }
    public Class Class { get; set; }
    public ICollection<Subject> Subjects {get; set;}
}     