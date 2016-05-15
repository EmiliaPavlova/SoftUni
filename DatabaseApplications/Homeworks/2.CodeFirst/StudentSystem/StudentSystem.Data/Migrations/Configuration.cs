namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Student_System.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemEntity>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemEntity";
        }

        protected override void Seed(StudentSystemEntity context)
        {
            if (!context.Students.Any())
            {
                var student = new Student()
                {
                    Name = "Nia Smith",
                    PhoneNumber = "123 456 789",
                    RegistrationDate = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Name = "DBA course",
                            Description = "Database Applications",
                            StartDate = new DateTime(2015,07,01),
                            EndDate = new DateTime(2015,08,03),
                            Price = 490m,
                            Homeworks = new List<Homework>()
                            {
                                new Homework()
                                {
                                    Content = "Code First",
                                    SubmissionDate = DateTime.Now,
                                    ContentType = ContentType.ApplicationZip
                                }
                            },
                            Resources = new List<Resource>()
                            {
                                new Resource()
                                {
                                    Name = "Video",
                                    ResouceType = ResouceType.Other,
                                    Url = "https://softuni.bg/Trainings/Resources/Video/5137/Video-16-July-2015-Atanas-Rusenov-Database-Applications-Jul-2015"
                                }
                            }
                        }
                    }
                };

                context.Students.Add(student);
                context.SaveChanges();
            }

            base.Seed(context);
        }
    }
}
