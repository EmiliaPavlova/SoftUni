namespace Blobs.Models
{
    using EventHandlers;
    using Events;
    using Interfaces;

    public class Blob : IBlob
    {
        private readonly int halfHealth;

        private int health;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Behavior = behavior;
            this.Attack = attack;

            this.halfHealth = this.Health / 2;
        }

        public string Name { get; }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                    if (this.Behavior.AlreadyTriggered)
                    {
                        string message = $"Blob {this.Name} was killed";
                        this.OnBlobDead?.Invoke(this, new BlobDeadEventArgs(message));
                    }
                }

                if (this.health <= this.halfHealth && !this.Behavior.AlreadyTriggered)
                {
                    this.Behavior.Trigger(this);
                    string message = $"Blob {this.Name} toggled {this.Behavior.GetType().Name}Behavior";
                    this.OnBehaviorToggled?.Invoke(this, new BehaviorToggledEventArgs(message));
                }
            }
        }

        public int Damage { get; set; }

        public bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
        }

        public IBehavior Behavior { get; }

        public IAttack Attack { get; }

        public void Respond(int damage)
        {
            this.Health -= damage;
        }

        public void PerformAttack(IBlob target)
        {
            this.Attack.ExecuteEffectsOnAttacker(this);
            this.Attack.ExecuteAttack(target, this.Damage);
        }

        public void Update()
        {
            if (this.Behavior.IsTriggered)
            {
                this.Behavior.PerformNegativeEffects(this);
            }
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"Blob {this.Name} KILLED";
            }

            return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }

        public event BehaviorToggledEventHandler OnBehaviorToggled;

        public event BlobDeadEventHandler OnBlobDead;
    }
}
