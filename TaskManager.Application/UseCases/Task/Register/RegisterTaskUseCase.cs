using TaskManager.Communication.Request;
using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCases.Task.Register;

public class RegisterTaskUseCase
{
    public ResponseTaskRegisterJson Execute(RequestTaskJson request)
    {
        return new ResponseTaskRegisterJson
        {
            Id = 1,
            Name = request.Name
        };
    }
}