using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApiEscuelaContextSeed
{
    public static async Task SeedAsync(ApiEscuelaContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Classes.Any())
            {
                using (var readerClass = new StreamReader("../Persistence/Data/Csv/Class.csv"))
                {
                    using (var csv = new CsvReader(readerClass, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Class>();
                        context.Classes.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Teachers.Any())
            {
                using (var readerStudents = new StreamReader("../Persistence/Data/Csv/Teacher.csv"))
                {
                    using (var csv = new CsvReader(readerStudents, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Teacher>();
                        List<Teacher> entidad = new List<Teacher>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Teacher
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Lastname = item.Lastname
                            });
                        }

                        context.Teachers.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Students.Any())
            {
                using (var readerStudents = new StreamReader("../Persistence/Data/Csv/Student.csv"))
                {
                    using (var csv = new CsvReader(readerStudents, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Student>();
                        List<Student> entidad = new List<Student>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Student
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Lastname = item.Lastname,
                                ClassIdFk = item.ClassIdFk

                            });
                        }

                        context.Students.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }

                }
            }
            if (!context.Users.Any())
            {
                using (var readerUser= new StreamReader("../Persistence/Data/Csv/User.csv"))
                {
                    using (var csv = new CsvReader(readerUser, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<User>();
                        List<User> entidad = new List<User>();
                        foreach (var item in list)
                        {
                            entidad.Add(new User
                            {
                                Id = item.Id,
                                Email = item.Email,
                                Password = item.Password

                            });
                        }

                        context.Users.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }

                }
            }
           
            if (!context.Subjects.Any())
            {
                using (var readerSubject = new StreamReader("../Persistence/Data/Csv/Subject.csv"))
                {
                    using (var csv = new CsvReader(readerSubject, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Subject>();
                        List<Subject> entidad = new List<Subject>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Subject
                            {
                                Id = item.Id,
                                Name = item.Name,
                                TeacherIdFk = item.TeacherIdFk,
                                StudentIdFk = item.StudentIdFk
                            });
                        }

                        context.Subjects.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }

                }
            }
            if (!context.Grades.Any())
            {
                using (var readerSubject = new StreamReader("../Persistence/Data/Csv/Grade.csv"))
                {
                    using (var csv = new CsvReader(readerSubject, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Grade>();
                        List<Grade> entidad = new List<Grade>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Grade
                            {
                                Id = item.Id,
                                SubjectIdFk = item.SubjectIdFk,
                                Score = item.Score
                            });
                        }

                        context.Grades.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }

                }
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiEscuelaContext>();
            logger.LogError(ex.Message);
        }
    }

    public static async Task SeedRolesAsync(ApiEscuelaContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>()
                        {
                            new Role{Id=1, Name="Student"},
                            new Role{Id=2, Name="Teacher"},

                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiEscuelaContext>();
            logger.LogError(ex.Message);
        }
    }
}