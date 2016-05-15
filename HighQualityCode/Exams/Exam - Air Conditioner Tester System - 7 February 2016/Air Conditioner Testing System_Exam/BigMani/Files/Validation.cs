namespace AirConditionerSystem.Files
{
    public static class Validation
    {
        public const int ManufacturerMinLength = 4;
        public const int ModelMinLength = 2;
        public const int PowerUsageMinLevel = 0;
        public const int VolumeCoveredMinLevel = 0;
        public const int ElectricityUsedMinLevel = 0;
        public const int CarMinVolume = 3;
        public const int PlaneMinElectricity = 150;
        //public const string INCORRECT_PROPERTY_LENGTH = "{0}'s name must be at least {1} symbols long.";
        public const string NoReport = "No reports.";
        public const string InvalidCommand = "Invalid command";
        public const string Status = "Jobs complete: {0:F2}%";
        //public const string INCORRECTRATING = "Energy efficiency rating must be between \"A\" and \"E\".";
        //public const string NONPOSITIVE = "{0} must be a positive integer.";
        public const string DuplicatedEntry = "An entry for the given model already exists.";
        public const string NonExist = "The specified entry does not exist.";
        public const string RegisteredSuccessfully = "Air Conditioner model {0} from {1} registered successfully.";
        public const string TestedSuccessfully = "Air Conditioner model {0} from {1} tested successfully.";

        
    }
}
