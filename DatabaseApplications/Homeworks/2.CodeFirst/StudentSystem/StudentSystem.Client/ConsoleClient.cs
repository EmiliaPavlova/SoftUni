namespace StudentSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;

    public class ConsoleClient
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemEntity();
            var studentsCount = context.Students.Count();
            Console.WriteLine(studentsCount);

            //1. Lists all students and their homework submissions. Select only their names and for each homework - content and content-type.
            var studentHomeworks = context.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Courses.Select(c => c.Homeworks
                        .Select(h => new
                        {
                            h.Content,
                            h.ContentType
                        }))
                })
                .ToList();

            studentHomeworks.ForEach(s =>
            {
                Console.WriteLine("{0}", s.Name);
                var homeworks = s.Homeworks.ToList();
                homeworks.ForEach(c =>
                {
                    c.ToList().ForEach(h => Console.WriteLine("Homework: {0} - {1}",
                        h.Content,
                        h.ContentType));
                });
            });

            //2. List all courses with their corresponding resources. Select the course name and description and everything for each resource. Order the courses by start date (ascending), then by end date (descending).
            var courses = context.Courses.Include(r => r.Resources)
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources
                })
                .ToList();

            courses.ForEach(c =>
            {
                Console.WriteLine("{0} - {1}", c.Name, c.Description);
                c.Resources.ToList().ForEach(r =>
                {
                    Console.WriteLine("{0}, {1} - {2}", r.Name, r.ResouceType, r.Url);
                });
            });

            //3. List all courses with more than 5 resources. Order them by resources count (descending), then by start date (descending). Select only the course name and the resource count.
            var coursesR = context.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderBy(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    CourseCount = c.Resources.Count
                })
                .ToList();
            coursesR.ForEach(Console.WriteLine);

            //4. List all courses which were active on a given date (choose the date depending on the data seeded to ensure there are results), and for each course count the number of students enrolled. Select the course name, start and end date, course duration (difference between end and start date) and number of students enrolled. Order the results by the number of students enrolled (in descending order), then by duration (descending).
            var date = DateTime.Now;
            var activeCouses = context.Courses
                .Where(c => c.StartDate < date && c.EndDate >= date)
                .ToList()
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c => (c.EndDate - c.StartDate).TotalDays)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    StudentCount = c.Students.Count,
                    CurseDuration = (c.EndDate - c.StartDate).TotalDays
                })
                .ToList();

            activeCouses.ForEach(c =>
            {
                Console.WriteLine("{0} [{1:dd-MM-yyyy} - {2:dd-MM-yyyy}]: {3} days, {4} students", c.Name, c.StartDate, c.EndDate, c.CurseDuration, c.StudentCount);
            });

            //5. For each student, calculate the number of courses he/she has enrolled in, the total price of these courses and the average price per course for the student. Select the student name, number of courses, total price and average price. Order the results by total price (descending), then by number of courses (descending) and then by the student's name (ascending).
            var students = context.Students
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Name)
                .Select(s => new
                {
                    s.Name,
                    NumOfCourses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AvgPrice = s.Courses.Sum(c => c.Price) / s.Courses.Count
                })
                .ToList();

            students.ForEach(s =>
            {
                Console.WriteLine("{0} - {1} courses, total price {2:F}, avg price {3:F}",
                    s.Name, s.NumOfCourses, s.TotalPrice, s.AvgPrice);
            });
        }
    }
}
