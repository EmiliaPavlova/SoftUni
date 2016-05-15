namespace _05.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_05.CodeFirst.DossierContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_05.CodeFirst.DossierContext";
        }

        protected override void Seed(_05.CodeFirst.DossierContext context)
        {
            
        }
    }
}
