namespace Photography_EF_Data_Model
{
    using System;
    using System.Linq;

    class ListCameras
    {
        static void Main()
        {
            var context = new PhotographyContext();
            var cameras = context.Cameras
                .Select(x => x.Manufacturer.Name + " " + x.Model)
                .OrderBy(x => x);
            Console.WriteLine(string.Join("\n", cameras));
        }
    }
}
