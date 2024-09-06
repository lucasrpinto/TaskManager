using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Response;

public class ResponseShortTaskJson
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public List<ResponseShortTaskJson> Task { get; set; }
}
