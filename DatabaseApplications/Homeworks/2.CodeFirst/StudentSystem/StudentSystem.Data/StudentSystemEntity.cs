namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Migrations;
    using Student_System.Models;

    public class StudentSystemEntity : DbContext
    {
        public StudentSystemEntity()
            : base("name=StudentSystemEntity")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemEntity, Configuration>());
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}