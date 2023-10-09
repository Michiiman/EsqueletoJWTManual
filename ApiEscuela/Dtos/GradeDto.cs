using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEscuela.Dtos;
public class GradeDto
{
        public int Id {get; set;}
        public int SubjectIdFk { get; set; }
        public SubjectDto Subject { get; set; }
        public float Score { get; set; }
}