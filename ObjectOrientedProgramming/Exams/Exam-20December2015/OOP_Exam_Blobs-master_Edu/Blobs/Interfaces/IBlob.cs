namespace Blobs.Interfaces
{
    using Models.EventHandlers;

    public interface IBlob : IAttackable, IAttacker, IUpdateable
    {
        string Name { get; }
        
        int Health { get; set; }
        
        int Damage { get; set; }

        bool IsAlive { get; }
        
        IBehavior Behavior { get; }
        
        IAttack Attack { get; }

        event BehaviorToggledEventHandler OnBehaviorToggled;
    }
}