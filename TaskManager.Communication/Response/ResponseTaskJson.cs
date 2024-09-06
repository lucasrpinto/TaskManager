using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Response;

public class ResponseTaskJson
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public TaskProgressStatus Status { get; set; }
}
