namespace Blobs.Interfaces
{
    public interface IBehaviorFactory
    {
        IBehavior Create(string behaviorName);
    }
}