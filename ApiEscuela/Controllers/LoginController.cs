using ApiEscuela.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiEscuela.Controllers;

public class LoginController : Controller
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public LoginController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpPost("getTokenLogin")]
    public ActionResult GetTokenLogin([FromForm] string email, [FromForm] string password)
    {
        Services.Login log = new Services.Login();
        return Ok(log.getTokenLogin(email, password));
    }


    [HttpPost("loginByToken")]
    public async Task<ActionResult> LoginByToken([FromForm] RegisterDto data)
    {
        Services.Login log = new Services.Login();
        User ent = await unitOfWork.Users.GetByEmailAsync(data.Email); // Traemos el objeto que concuerda con el Email.

        if (ent == null)
        {
            return BadRequest("Usuario no encontrado");
        }

        string token = log.LoginByToken(data.LoginToken, ent);

        switch (token)
        {
            case "-1": return BadRequest("Límite de tiempo excedido");
            case "-2": return BadRequest("Usuario o clave incorrectos");
            case "-3": return BadRequest("No se pudo hacer el login, revise los datos enviados");
            default: return Ok(token);
        }
    }

    [HttpPost("getNotas")]
    public async Task<ActionResult> GetNotas([FromForm] string token)
    {
        try
        {

            // Validar token
            Services.Login log = new Services.Login();
            if (!log.ValidarTokenUsuario(token))
            {
                return BadRequest("Token caducado o incorrecto");
            }
            // Ejecutar acción para obtener la lista de GradeDto
            var notas = await unitOfWork.Grades.GetAllAsync();

            // Convertir la lista de GradeDto a JSON y devolverla como una respuesta OK
            var notasDto = mapper.Map<List<GradeDto>>(notas);
            return Ok(notasDto);  // Envolver las notasDto en un OkObjectResult
        }
        catch (Exception ex)
        {
            // Manejar errores y devolver una respuesta de error BadRequest con el mensaje de error
            return BadRequest(ex.Message);
        }
    }
}
