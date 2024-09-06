using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.Delete;
using TaskManager.Application.UseCases.Task.GetAll;
using TaskManager.Application.UseCases.Task.GetById;
using TaskManager.Application.UseCases.Task.Register;
using TaskManager.Application.UseCases.Task.Update;
using TaskManager.Communication.Request;
using TaskManager.Communication.Response;

namespace TaskManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{

    // Typeof : Communication > Responses > ResponseErrorJson | ResponseTaskRegisterJson (Sucess and Error) 
    // Return : Application > UseCases > Task > Register > RegisterTaskUseCase (Return Informations)
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskRegisterJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestTaskJson request)
    {
        var response = new RegisterTaskUseCase().Execute(request);

        return Created(string.Empty, response);
    }

    // Typeof : Communication > Responses > ResponseErrorJson (Error) 
    // Return : Application > UseCases > Task > Update > UpdateTaskUseCase (Return Void)
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)] //SUCESS BUT NOT RETURN
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestTaskJson request)
    {
        var useCase = new UpdateTaskUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    // Typeof : Communication > Responses > ResponseErrorJson (Error) 
    // Return : Application > UseCases > Task > Delete > DeleteTaskUseCase (Return Void)
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)] //SUCESS BUT NOT RETURN
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Delete(int id)
    {
        var useCase = new DeleteTaskUseCase();

        useCase.Execute(id);

        return NoContent();
    }

    // GET ALL
    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTaskJson), StatusCodes.Status200OK)] 
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get()
    {
        var useCase = new GetAllTaskUseCase();

        var response = useCase.Execute();

        if (response.Task.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseAllTaskJson), StatusCodes.Status200OK)] 
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var useCase = new GetTaskByIdUseCase();

        var response = useCase.Execute(id);
        
        return Ok(response);
    }
}
