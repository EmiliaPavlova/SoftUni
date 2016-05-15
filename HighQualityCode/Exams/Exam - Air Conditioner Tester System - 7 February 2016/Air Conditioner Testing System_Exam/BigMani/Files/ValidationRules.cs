namespace AirConditionerSystem.Files
{
    using System;

    public static class ValidationRules
    {
        public static void CheckValidLenght(string value, int minLength, string paramName)
        {
            if (string.IsNullOrEmpty(value) || value.Length < minLength)
            {
                string message = string.Format("{0} must be at least {1} symbols long.", paramName, minLength);
                throw new ArgumentException(message);
            }
        }

        public static void CheckValidLevel(int value, int minLevel, string paramName)
        {
            if (value <= minLevel)
            {
                string message = string.Format("{0} must be a positive integer.", paramName);
                throw new ArgumentException(message);
            }
        }
    }
}