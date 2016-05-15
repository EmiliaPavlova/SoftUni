using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    using Course;

    class CoursesExamples
    {
        static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases", "Nasko", "Inspiration Lab");
            Console.WriteLine(localCourse);

            localCourse.AddStudent("Peter");
            localCourse.AddStudent("Maria");
            Console.WriteLine(localCourse);

            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            //localCourse.Students.Add("");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev", "Varna");
            offsiteCourse.AddStudent("Thomas");
            offsiteCourse.AddStudent("Ani");
            offsiteCourse.AddStudent("Steve");
            Console.WriteLine(offsiteCourse);
        }
    }
}
