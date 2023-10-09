using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RoleRepository : GenericRepository<Role>, IRole
{
    public RoleRepository(ApiEscuelaContext context) : base(context)
    {}
}