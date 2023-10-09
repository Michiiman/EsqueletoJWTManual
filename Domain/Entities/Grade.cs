using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Grade:BaseEntity
    {
        public int SubjectIdFk { get; set; }
        public Subject Subject { get; set; }
        public float Score { get; set; }
    }
}     