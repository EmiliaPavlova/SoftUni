using System;

namespace Methods
{
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Student
    {
        private string firstName ;

        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("firstName", "First name cannot be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("lastName", "Last name cannot be null or empty.");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo { get; set; }

        /// <summary>
        /// Checks if a student is older than another one
        /// </summary>
        /// <param name="other">The other student we compart the first one to.</param>
        /// <returns>The <see cref="bool"/>true or false</returns>
        public bool IsOlderThan(Student other)
        {
            try
            {
                DateTime firstStudentDateOfBirth = this.GetDateOfBirth(this.OtherInfo);
                DateTime secondStudentDateOfBirth = other.GetDateOfBirth(other.OtherInfo);
                return firstStudentDateOfBirth < secondStudentDateOfBirth;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentException("One or both students do not have valid date of birth information provided.");
            }
        }

        /// <summary>
        /// Gets the date of birth.
        /// </summary>
        /// <param name="info"></param>
        /// <returns>The <see cref="DateTime"/></returns>
        /// <exception cref="FormatException">Invalid date format></exception>
        public DateTime GetDateOfBirth(string info)
        {
            string[] paramArgs = info.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string dateInfo = paramArgs.Last().Substring(8).Trim();

            if (!IsValidBulgarianFormatDate(dateInfo))
            {
                throw new FormatException("Invalid date format.");
            }

            DateTime date = DateTime.Parse(dateInfo);

            return date;
        }

        /// <summary>
        /// Checks if the provided date of birth info string can be parsed into a valid date.
        /// </summary>
        /// <param name="dateInfo">The birthdate of the student in string</param>
        /// <returns>The <see cref="bool"/></returns>
        /// <exception cref="ArgumentNullException">Date if birth information is not provided.></exception>
        private static bool IsValidBulgarianFormatDate(string dateInfo)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            DateTime date;
            bool isValiDate = DateTime.TryParse(dateInfo, out date);

            return isValiDate;
        }
    }
}
