using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleIdFk { get; set; }
    public Role Role { get; set; }

}


