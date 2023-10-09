
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;
public class GradeRepository:GenericRepository<Grade> , IGrade
{
    protected readonly ApiEscuelaContext _context;
    public GradeRepository(ApiEscuelaContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Grade>> GetAllAsync()
    {
        return await _context.Grades
        .Include(p=>p.Subject).ThenInclude(p=>p.Teacher)
        .Include(p=>p.Subject).ThenInclude(p=>p.Student).ThenInclude(p=>p.Class)
        .ToListAsync();
    }

    public override async Task<Grade> GetByIdAsync(int id)
    {
        return await _context.Grades
        .Include(p=>p.Subject).ThenInclude(p=>p.Teacher)
        .Include(p=>p.Subject).ThenInclude(p=>p.Student).ThenInclude(p=>p.Class)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
