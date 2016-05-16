using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Point3D;

namespace Task3.Paths
{
    public static class Storage
    {
        public static void Save(string sequenceOFPoints, string name)
        {
            var points = sequenceOFPoints.Split('|').ToList();
            using (var writer = new StreamWriter("../../" + name + ".txt"))
            {
                points.ForEach(x =>
                {
                    var coordinates = x.Split(' ');
                    writer.WriteLine("({0},{1},{2})", coordinates[0], coordinates[1], coordinates[2]);
                });
            }
        }

        public static void Save(List<Point3D> sequenceOFPoints, string name)
        {
            using (var writer = new StreamWriter("../../" + name + ".txt"))
            {
                sequenceOFPoints.ForEach(x => writer.WriteLine(x));
            }
        }

        public static string Load(string name)
        {
            var allText = new List<string>();
            using (var reader = new StreamReader("../../" + name + ".txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    allText.Add(line);
                    line = reader.ReadLine();
                }
            }

            return string.Join("|", allText);
        }
    }
}
