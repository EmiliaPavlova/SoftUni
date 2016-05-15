namespace CohesionAndCoupling
{
    using System;

    public class FileUtil
    {
        /// <summary>
        /// Method that returns file extensions or empty string if no file extension
        /// </summary>
        /// <param name="fileName">string representing file name</param>
        /// <returns><see cref="string"/>extension</returns>
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return String.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);

            return extension;
        }

        /// <summary>
        /// Method that returns file name without extension
        /// </summary>
        /// <param name="fileName">string representing file name</param>
        /// <returns><see cref="string"/>file name without extension</returns>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);

            return extension;
        }
    }
}