namespace BoatRacingSimulator.Database
{
    using System.Collections.Generic;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public class Repository<T> : IRepository<T> where T : IModelable
    {
        public Repository()
        {
            this.ItemsByModel = new Dictionary<string, T>();
        }

        protected Dictionary<string, T> ItemsByModel { get; set; }

        public virtual void Add(T item)
        {
            if (this.ItemsByModel.ContainsKey(item.Model))
            {
                throw new DuplicateModelException(Constants.DuplicateModelMessage);
            }

        }

        public virtual T GetItem(string model)
        {
            if (!this.ItemsByModel.ContainsKey(model))
            {
                throw new NonExistantModelException(Constants.NonExistantModelMessage);
            }

            return this.ItemsByModel[model];
        }
    }
}
