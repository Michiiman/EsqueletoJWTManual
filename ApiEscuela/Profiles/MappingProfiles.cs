
using ApiEscuela.Dtos;
using AutoMapper;
using Domain.Entities;

namespace ApiEscuela.Profiles;
public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Class,ClassDto>().ReverseMap();
        CreateMap<Grade,GradeDto>().ReverseMap();
        CreateMap<Student,StudentDto>().ReverseMap();
        CreateMap<Subject,SubjectDto>().ReverseMap();
        CreateMap<Teacher,TeacherDto>().ReverseMap();
        CreateMap<Role,RoleDto>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
    }
    
}