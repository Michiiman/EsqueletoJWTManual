using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class UserRepository : GenericRepository<User>, IUser
{
    protected readonly ApiEscuelaContext _context;
    public UserRepository(ApiEscuelaContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(p => p.Role)
            .ToListAsync();
    }
    public override async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users
        .Include(p => p.Role)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

}
