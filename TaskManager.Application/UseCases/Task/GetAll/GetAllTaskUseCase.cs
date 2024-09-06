using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCases.Task.GetAll;

public class GetAllTaskUseCase
{
    public ResponseAllTaskJson Execute()
    {
        return new ResponseAllTaskJson
        {
            Task = new List <ResponseShortTaskJson>
            {
                new ResponseShortTaskJson
                {
                    Id = 1,
                    Name = "Test",
                    Priority = Communication.Enums.TaskPriority.Media,

                }
            }
        };
    }
}

