using System.Collections.Generic;
using System.Linq;
using BigMani.Exceptions;
using BigMani.Files;


namespace BigMani.GoodStuff
{
    public static class MyStuff
    {
        static MyStuff()
        {
            AirConditioners = new List<BlowWind>();
            Reports = new List<Reprot>();
        }

        internal static List<BlowWind> AirConditioners { get;  set; }

        public static List<Reprot> Reports { get;  set; }

        internal static void AddAirConditioner(BlowWind airConditioner)
        {
            AirConditioners.Add(airConditioner);
        }

        internal static void RemoveAirConditioner(BlowWind airConditioner)
        {
            AirConditioners.Remove(airConditioner);
        }

        internal static BlowWind GetAirConditioner(string manufacturer, string model)
        {
            return AirConditioners.Where(x => x.Manufacturer == manufacturer && x.Model == model).First();
        }

        internal static int GetAirConditionersCount()
        {
            return AirConditioners.Count;
        }

        public static void AddReport(Reprot report)
        {
            Reports.Add(report);
        }

        public static void RemoveReport(Reprot report)
        {
            Reports.Remove(report);
        }

        public static Reprot GetReport(string manufacturer, string model)
        {
            return Reports.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
        }

        public static int GetReportsCount()
        {
            return Reports.Count;
        }

        public static List<Reprot> GetReportsByManufacturer(string manufacturer)
        {
            return Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}
