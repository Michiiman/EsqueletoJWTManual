

namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IClass Classes { get; }
    IGrade Grades { get; }
    IRole Roles { get; }
    IStudent Students { get; }
    ISubject Subjects { get; }
    ITeacher Teachers { get; }
    IUser Users { get; }
    Task<int> SaveAsync();
}