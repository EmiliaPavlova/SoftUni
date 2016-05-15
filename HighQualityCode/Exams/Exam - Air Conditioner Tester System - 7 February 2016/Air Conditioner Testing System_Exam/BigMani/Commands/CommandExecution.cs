namespace AirConditionerSystem.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Controllers;
    using Core;
    using Files;
    using Models;
    using Report = Files.Report;

    public class CommandExecution
    {
        //public AirConditionarSystemEngine engine;

        //public CommandExecution(AirConditionarSystemEngine vrooom)
        //{
        //    this.engine = vrooom;
        //}

        public void Execute()
        {
            var command;
            try
            {
                switch (command)
                {
                    case "RegisterStationaryAirConditioner":
                        this.engine.ValidateParametersCount(command, 4);
                        this.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            char.Parse(command.Parameters[2]),
                            int.Parse(command.Parameters[3]));
                        break;
                    case "RegisterCarAirConditioner":
                        this.engine.ValidateParametersCount(command, 3);
                        this.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]));
                        break;
                    case "RegisterPlaneAirConditioner":
                        this.engine.ValidateParametersCount(command, 4);
                        this.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            command.Parameters[3]);
                        break;
                    case "TestAirConditioner":
                        this.engine.ValidateParametersCount(command, 2);
                        this.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "FindAirConditioner":
                        this.engine.ValidateParametersCount(command, 2);
                        this.FindAirConditioner(
                            command.Parameters[1],
                            command.Parameters[0]);
                        break;
                    case "FindReport":
                        this.engine.ValidateParametersCount(command, 2);
                        this.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "Status":
                        this.engine.ValidateParametersCount(command, 0);
                        this.engine.Status();
                        break;
                    default:
                        throw new IndexOutOfRangeException(Validation.InvalidCommand);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Validation.InvalidCommand, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Validation.InvalidCommand, ex.InnerException);
            }
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, int powerUsage, RequiredEnergyEfficiencyRating energyEfficiencyRating)
        {
            AirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, powerUsage, energyEfficiencyRating);
            Controller.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(string.Format(Validation.RegisteredSuccessfully, airConditioner.Model, airConditioner.Manufacturer));
        }

        public string RegisterCarAirConditioner(string model, string manufacturer, int volumeCoverage)
        {
            AirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);
            Controller.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(
                string.Format(Validation.RegisteredSuccessfully, airConditioner.Model, airConditioner.Manufacturer));
        }

        /// <summary>
        /// Method used to register plane air conditioners
        /// </summary>
        /// <param name="manufacturer">the name of the manufacturer</param>
        /// <param name="model">the model of the air conditioner</param>
        /// <param name="volumeCoverage"></param>
        /// <param name="electricityUsed"></param>
        /// <returns>Returns a message with the model and manufacturer of the air conditioner if registered successfully.</returns>
        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, int electricityUsed)
        {
            AirConditioner airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            Controller.AirConditioners.Add(airConditioner);
            //throw new InvalidOperationException(
            //    string.Format(GoodStuff.TEST, airConditioner.Model, airConditioner.Manufacturer));

            return Validation.RegisteredSuccessfully;
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = Controller.GetAirConditioner(manufacturer, model);
            //airConditioner.energyRating += 5;
            Mark mark = airConditioner.Test();
            Controller.Reports.Add(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            //throw new InvalidOperationException(string.Format(GoodStuff.TEST, model, manufacturer));

            return Validation.TestedSuccessfully;
        }

        /// <summary>
        /// finds if such air conditioner already exist
        /// </summary>
        /// <param name="manufacturer">the name of the manufacturer</param>
        /// <param name="model">the model of the air conditioner</param>
        /// <returns></returns>
        public string FindAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = Controller.GetAirConditioner(manufacturer, model);
            //throw new InvalidOperationException(airConditioner.ToString());

            return airConditioner.ToString();
        }

        public string FindReport(string manufacturer, string model)
        {
            Report report = Controller.GetReport(manufacturer, model);
            //throw new InvalidOperationException(report.ToString());

            return report.ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<Report> reports = Controller.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Validation.NoReport;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));

            return reportsPrint.ToString();
        }
    }
}
