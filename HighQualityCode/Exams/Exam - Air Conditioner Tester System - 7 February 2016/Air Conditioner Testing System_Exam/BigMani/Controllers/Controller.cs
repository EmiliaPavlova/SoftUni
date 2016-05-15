namespace AirConditionerSystem.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Report = Files.Report;

    public static class Controller
    {
        static Controller()
        {
            AirConditioners = new List<AirConditioner>();
            Reports = new List<Report>();
        }

        internal static List<AirConditioner> AirConditioners { get; set; }

        public static List<Report> Reports { get; set; }

        internal static void AddAirConditioner(AirConditioner airConditioner)
        {
            AirConditioners.Add(airConditioner);
        }

        internal static void RemoveAirConditioner(AirConditioner airConditioner)
        {
            AirConditioners.Remove(airConditioner);
        }

        internal static AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            return AirConditioners
                .Where(x => x.Manufacturer == manufacturer && x.Model == model)
                .First();
        }

        internal static int GetAirConditionersCount()
        {
            return AirConditioners.Count;
        }

        public static void AddReport(Report report)
        {
            Reports.Add(report);
        }

        public static void RemoveReport(Report report)
        {
            Reports.Remove(report);
        }

        public static Report GetReport(string manufacturer, string model)
        {
            return Reports
                .Where(x => x.Manufacturer == manufacturer && x.Model == model)
                .FirstOrDefault();
        }

        public static int GetReportsCount()
        {
            return Reports.Count;
        }

        public static List<Report> GetReportsByManufacturer(string manufacturer)
        {
            return Reports
                .Where(x => x.Manufacturer == manufacturer)
                .ToList();
        }
    }
}
