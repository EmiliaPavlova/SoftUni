using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1.HumanStudentAndWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Students:");
            var students = new List<Student>()
            {
                new Student("Pesho", "Peshev", "st001"),
                new Student("Ivo", "Ivanov", "st846"),
                new Student("Maria", "Dimitrova", "st649"),
                new Student("Nia", "Petrova", "st085"),
                new Student("Lili", "Mileva", "st799"),
                new Student("Kiril", "Kirilov", "st566"),
                new Student("Stoyan", "Peshev", "st569"),
                new Student("Ilia", "Iliev", "st356"),
                new Student("Misho", "Green", "st118"),
                new Student("Ana", "Radeva", "st212"),
            };
            var sortedStudents = students.OrderBy(x => x.FacultyNumber);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0}, {1}", student, student.FacultyNumber);
            }

            Console.WriteLine("Workers:");
            var workers = new List<Worker>()
            {
                new Worker("Ed", "Smith", 13.3M, 20.0M),
                new Worker("Lin", "Lilova", 14.3M, 13.4M),
                new Worker("Maya", "Krasimirova", 15.3M, 13.6M),
                new Worker("Haris", "Popov", 12.3M, 8.9M),
                new Worker("Dimo", "Dimov", 10.3M, 13.4M),
                new Worker("Angel", "Iliev", 130.3M, 13.4M),
                new Worker("Kalin", "Velev", 112.3M, 15.4M),
                new Worker("Vili", "Moneva", 13123.3M, 13.4M),
                new Worker("Eli", "Nedeva", 113.3M, 13.4M),
                new Worker("Peter", "Inkov", 3.3M, 13.4M),
            };

            var sortedWorkers = workers.OrderByDescending(x => x.WorkHoursPerDay);
            foreach (var sortedWorker in sortedWorkers)
            {
                Console.WriteLine("{0}, {1:F2} lv.", sortedWorker, sortedWorker.WorkHoursPerDay);
            }
        }
    }
}
