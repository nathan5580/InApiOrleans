namespace InApiOrleans.Grains;

public interface ITaskGrain : IGrainWithGuidKey
{
    Task AssignToDesk(Guid deskId);
}

public class TaskGrain : Grain, ITaskGrain
{
    public async Task AssignToDesk(Guid deskId)
    {
        var deskGrain = GrainFactory.GetGrain<IDeskGrain>(deskId);
        await deskGrain.AddTask(this.GetPrimaryKey());
        // Additional logic as needed
    }
}