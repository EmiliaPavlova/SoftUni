

using BigMani.Files;
using BigMani.GoodStuff;

using BigMani.Wokr;
using BigMani.Exceptions;
namespace BigMani.Work
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Baito
    {
        public Engine vroom;

        public Baito(Engine vrooom)
        {
            this.vroom = vrooom;
        }

        public void DoMagic()
        {
            var magic = vroom.magic;
            try
            {
                switch (magic.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        vroom.ValidateParametersCount(magic, 4);
                        RegisterStationaryAirConditioner(
                            magic.Parameters[0],
                            magic.Parameters[1],
                            magic.Parameters[2],
                            int.Parse(magic.Parameters[3]));
                        break;
                    case "RegisterCarAirConditioner":
                        vroom.ValidateParametersCount(magic, 3);
                        RegisterCarAirConditioner(
                            magic.Parameters[0],
                            magic.Parameters[1],
                            int.Parse(magic.Parameters[2]));
                        break;
                    case "RegisterPlaneAirConditioner":
                        vroom.ValidateParametersCount(magic, 4);
                        RegisterPlaneAirConditioner(
                            magic.Parameters[0],
                            magic.Parameters[1],
                            int.Parse(magic.Parameters[2]),
                            magic.Parameters[3]);
                        break;
                    case "TestAirConditioner":
                        vroom.ValidateParametersCount(magic, 2);
                        TestAirConditioner(
                            magic.Parameters[0],
                            magic.Parameters[1]);
                        break;
                    case "FindAirConditioner":
                        vroom.ValidateParametersCount(magic, 2);
                        FindAirConditioner(
                            magic.Parameters[1],
                            magic.Parameters[0]);
                        break;
                    case "FindReport":
                        vroom.ValidateParametersCount(magic, 2);
                        FindReport(
                            magic.Parameters[0],
                            magic.Parameters[1]);
                        break;
                    case "Status":
                        vroom.ValidateParametersCount(magic, 0);
                        vroom.Status();
                        break;
                    default:
                        throw new IndexOutOfRangeException(GoodStuff.GoodStuff.INVALIDCOMMAND);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(GoodStuff.GoodStuff.INVALIDCOMMAND, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(GoodStuff.GoodStuff.INVALIDCOMMAND, ex.InnerException);
            }
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            BlowWind airConditioner = new BlowWind(manufacturer, model, energyEfficiencyRating, powerUsage);
            MyStuff.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(string.Format(GoodStuff.GoodStuff.REGISTER, airConditioner.Model, airConditioner.Manufacturer));
        }

        public string RegisterCarAirConditioner(string model, string manufacturer, int volumeCoverage)
        {
            BlowWind airConditioner = new BlowWind(manufacturer, model, volumeCoverage);
            MyStuff.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(
                string.Format(GoodStuff.GoodStuff.REGISTER, airConditioner.Model, airConditioner.Manufacturer));
        }

        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            BlowWind airConditioner = new BlowWind(manufacturer, model, volumeCoverage, electricityUsed);
            MyStuff.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(
                string.Format(GoodStuff.GoodStuff.TEST, airConditioner.Model, airConditioner.Manufacturer));
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            BlowWind airConditioner = MyStuff.GetAirConditioner(manufacturer, model);
            airConditioner.energyRating += 5;
            var mark = airConditioner.Test();
            MyStuff.Reports.Add(new Reprot(airConditioner.Manufacturer, airConditioner.Model, mark));
            throw new InvalidOperationException(string.Format(GoodStuff.GoodStuff.TEST, model, manufacturer));
        }

        public string FindAirConditioner(string manufacturer, string model)
        {
            BlowWind airConditioner = MyStuff.GetAirConditioner(manufacturer, model);
            throw new InvalidOperationException(airConditioner.ToString());
        }

        public string FindReport(string manufacturer, string model)
        {
            Reprot report = MyStuff.GetReport(manufacturer, model);
            throw new InvalidOperationException(report.ToString());
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<Reprot> reports = MyStuff.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return GoodStuff.GoodStuff.NOREPORTS;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }
    }
}
