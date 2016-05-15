using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using _05.CodeFirst;
using _05.CodeFirst.Models;
using _05.CodeFirst.Models.DTO;

namespace _05._1.ImportData
{
    class ImportData
    {
        static void Main(string[] args)
        {
            //ImportCities();
            ImportActivityTypes();
            //ImportIndividuals();
        }

        private static void ImportIndividuals()
        {
            var context = new DossierContext();
            var individualsJson = File.ReadAllText("../../individuals.json");
            var individuals = JsonConvert.DeserializeObject<IEnumerable<IndividualDto>>(individualsJson);

            foreach (var individual in individuals)
            {
                var individualEntity = new Individual
                {
                    FullName = individual.FullName,
                    Alias = individual.Alias,
                    BirthDate = individual.BirthDate,
                    Status = individual.Status
                };

                context.Individuals.Add(individualEntity);
            }

            context.SaveChanges();
        }

        private static void ImportActivityTypes()
        {
            var context = new DossierContext();
            var activitiesJson = File.ReadAllText("../../activity-types.json");
            var activities = JsonConvert.DeserializeObject<IEnumerable<ActivityTypeDto>>(activitiesJson);
            foreach (var activity in activities)
            {
                var activityEntity = new ActivityType
                {
                    Name = activity.Name
                };

                context.ActivityTypes.Add(activityEntity);
            }

            context.SaveChanges();
        }

        private static void ImportCities()
        {
            var context = new DossierContext();
        }
    }
}
