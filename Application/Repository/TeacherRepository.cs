using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class TeacherRepository : GenericRepository<Teacher>, ITeacher
{
    protected readonly ApiEscuelaContext _context;
    public TeacherRepository(ApiEscuelaContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _context.Teachers
        .ToListAsync();
    }
    public override async Task<Teacher> GetByIdAsync(int id)
    {
        return await _context.Teachers
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
