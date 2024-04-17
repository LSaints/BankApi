using BankApplication.Domain;
using BankApplication.Manager;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BankApplication.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserUseCase _useCase;
    public UserController(IUserUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet(Name = "getAll")]
    [SwaggerOperation(Summary = "Obter a lista de todos os usuarios")]
    [SwaggerResponse(StatusCodes.Status200OK, "Usuários retornados com sucesso")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no servidor")]
    public async Task<ActionResult> GetAll() 
    {
        try 
        {
            return  Ok(await _useCase.GetAll());
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter usuario com Id especificado")]
    [SwaggerResponse(StatusCodes.Status200OK, "Usuário retornado com sucesso")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no servidor")]
    public async Task<ActionResult> GetById(Guid id) 
    {
        try 
        {
            return Ok(await _useCase.GetById(id));
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Criar novo usuário")]
    [SwaggerResponse(StatusCodes.Status201Created, "Usuário criado com sucesso")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no servidor")]
    public async Task<ActionResult> Create([FromBody] UserInputModel user) 
    {
        try 
        {
            var entity = await _useCase.Create(user);
            return CreatedAtAction(nameof(GetAll),  entity);
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost("deposit/{Id}")]
    [SwaggerOperation(Summary = "Depositar valor")]
    [SwaggerResponse(StatusCodes.Status201Created, "Valor depositado com sucesso")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no servidor")]
    public async Task<ActionResult> Deposit(Guid Id, double Amount) 
    {
        try 
        {
            var entity = await _useCase.Deposit(Id, Amount);
            return CreatedAtAction(nameof(GetAll),  entity);
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Alterar dados do usuario especificado")]
    [SwaggerResponse(StatusCodes.Status200OK, "Usuário alterado com sucesso")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no servidor")]
     public async Task<ActionResult> Update([FromBody] UserUpdateModel user) 
    {
        try 
        {
            var userFind = await _useCase.Update(user);
            return Ok(userFind);
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    [SwaggerOperation(Summary = "Deletar usuario especificado")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Usuário Deletado com sucesso")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no servidor")]
     public async Task<IActionResult> Remove(Guid id) 
    {
        try 
        {
            var userFind = await _useCase.Delete(id);
            return NoContent();
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
