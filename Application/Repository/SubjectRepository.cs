using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class SubjectRepository : GenericRepository<Subject>, ISubject
{
    protected readonly ApiEscuelaContext _context;
    public SubjectRepository(ApiEscuelaContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Subject>> GetAllAsync()
    {
        return await _context.Subjects
            .Include(p => p.Student).ThenInclude(p=>p.Class)
            .Include(p => p.Teacher)
            .ToListAsync();
    }
    public override async Task<Subject> GetByIdAsync(int id)
    {
        return await _context.Subjects
        .Include(p => p.Student)
        .Include(p => p.Teacher)
        
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
