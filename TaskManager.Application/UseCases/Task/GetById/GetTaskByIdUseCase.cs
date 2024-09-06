using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCases.Task.GetById;

public class GetTaskByIdUseCase
{
    public ResponseTaskJson Execute(int id)
    {
        return new ResponseTaskJson
        {
            Id = id,
            Name = "TESTE",
            Description = "TESTE TESTE",
            Priority = Communication.Enums.TaskPriority.Alta,
            Status = Communication.Enums.TaskProgressStatus.Em_Andamento
        };
    }
}
