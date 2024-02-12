namespace InApiOrleans.Grains;

public interface IDeskGrain : IGrainWithGuidKey
{
    Task AddTask(Guid taskId);
    Task<List<Guid>> GetTasks();
}

public class DeskGrain : Grain, IDeskGrain
{
    private List<Guid> _tasks = new List<Guid>();

    public Task AddTask(Guid taskId)
    {
        if (!_tasks.Contains(taskId))
        {
            _tasks.Add(taskId);
            // Optionally, notify the TaskGrain or perform other logic
        }
        return Task.CompletedTask;
    }

    public Task<List<Guid>> GetTasks()
    {
        return Task.FromResult(_tasks);
    }
}