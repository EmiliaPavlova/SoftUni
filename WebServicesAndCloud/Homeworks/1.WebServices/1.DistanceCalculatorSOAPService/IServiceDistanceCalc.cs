namespace _1.DistanceCalculatorSOAPService
{
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceDistanceCalc
    {

        [OperationContract]
        double CalcDistance(Point startPoint, Point endPoint);
    }
}
