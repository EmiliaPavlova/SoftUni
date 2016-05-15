namespace InheritanceAndPolymorphism.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for class that creates courses
    /// </summary>
    public interface ICourse
    {
        string CourseName { get; }

        string TeacherName { get; }

        IList<string> Students { get; }

        /// <summary>
        /// Method that adds students in course
        /// </summary>
        /// <param name="studentName">The student to be added</param>
        void AddStudent(string studentName);
    }
}