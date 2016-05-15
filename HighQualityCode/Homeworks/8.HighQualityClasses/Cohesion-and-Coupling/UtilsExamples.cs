using System;

namespace CohesionAndCoupling
{
    public class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtil.GetFileExtension("example"));
            Console.WriteLine(FileUtil.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtil.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtil.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtil.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtil.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                PolygonUtil.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                PolygonUtil.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Util paralelepiped = new Util(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", paralelepiped.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", paralelepiped.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", paralelepiped.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", paralelepiped.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", paralelepiped.CalcDiagonalYZ());
        }
    }
}
