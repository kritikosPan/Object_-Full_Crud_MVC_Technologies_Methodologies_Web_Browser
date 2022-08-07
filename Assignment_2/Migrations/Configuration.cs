namespace Assignment_2.Migrations
{
    using Assignment_2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment_2.MyContext.ApllicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assignment_2.MyContext.ApllicationContext context)
        {   

            Trainer t1 = new Trainer() { FirstName = "Panagiotis", LastName = "Kritikos", Subject = "C#" };
            Trainer t2 = new Trainer() { FirstName = "Andreas", LastName = "Grigoropoulos", Subject = "Java" };
            Trainer t3 = new Trainer() { FirstName = "Georgios", LastName = "Gitonas", Subject = "SAP" };

            context.Trainers.AddOrUpdate(x => x.FirstName, t1, t2, t3);
            context.SaveChanges();

            



        }
    }
}
