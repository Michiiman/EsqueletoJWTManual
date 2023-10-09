using ApiEscuela.Dtos;
using ApiEscuela.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ApiEscuela.Controllers;

public class UserController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IUserService _userService;

    public UserController(IUnitOfWork unitOfWork, IMapper mapper,IUserService userService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this._userService =userService;
    }


    //Metodos Basicos
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var entidad = await unitOfWork.Users.GetAllAsync();
        return mapper.Map<List<UserDto>>(entidad);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> Put(int id, [FromBody] UserDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<User>(entidadDto);
        unitOfWork.Users.Update(entidad);
        await unitOfWork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitOfWork.Users.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitOfWork.Users.Remove(entidad);
        await unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult> RegisterAsync(PostEncryptDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }

    

}
