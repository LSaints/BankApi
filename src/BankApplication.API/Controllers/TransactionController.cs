using BankApplication.Domain;
using BankApplication.Manager;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BankApplication.API;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionUseCase _useCase;

    public TransactionController(ITransactionUseCase useCase) 
    {
        _useCase = useCase;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Obter a lista de todas as transações")]
    [SwaggerResponse(StatusCodes.Status200OK, "Transações retornadas com sucesso")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no servidor")]
    public async Task<ActionResult> GetAll()
    {
        try 
        {
            return Ok(await _useCase.GetAll());
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter Transação com Id especificado")]
    [SwaggerResponse(StatusCodes.Status200OK, "Transação retornada com sucesso")]
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
    [SwaggerOperation(Summary = "Criar uma nova transação")]
    [SwaggerResponse(StatusCodes.Status201Created, "Transação criada com sucesso")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no servidor")]
    public async Task<ActionResult> Create([FromBody] Transaction transaction) 
    {
        try 
        {
            var entity = await _useCase.Create(transaction);
            return CreatedAtAction(nameof(GetAll),  entity);
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
