using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.ZippingSlicedFiles
{
    class ZippingSlicedFiles
    {
        static void Main(string[] args)
        {
            string sourceFile = "../../Wildlife.wmv";
            string destinationDirectory = "../../";
            int parts = 5;
            Slice(sourceFile, destinationDirectory, parts);
            Assemble(new List<string>()
            {
                "../../part-1.gz",
                "../../part-2.gz",
                "../../part-3.gz",
                "../../part-4.gz",
                "../../part-5.gz",
            }, "../../");

            Console.WriteLine("Ready. Check in folder 6.ZippingSlicedFiles");
        }
        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            } 

            byte[] buffer = new byte[Environment.SystemPageSize];
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                long startBytes = 0;
                long partLength = source.Length / parts;
                for (int i = 0; i < parts; i++)
                {                    
                    string destinationFile = string.Format("{1}/part-{0}.gz", i + 1, destinationDirectory);
                    long endBytes = partLength * (i + 1);
                    using (var destination = new FileStream(destinationFile, FileMode.Create))
                    {
                        using (var gzipStream = new GZipStream(destination, CompressionMode.Compress))
                        {
                            while (startBytes < endBytes)
                            {
                                int readBytes = source.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }

                                gzipStream.Write(buffer, 0, readBytes);
                                startBytes += readBytes;
                            }   
                        }
                    }    
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            byte[] buffer = new byte[Environment.SystemPageSize];
            FileInfo fi = new FileInfo(files[0]);
            var ext = fi.Extension;
            string destinationPath = string.Format("{0}/result.{1}", destinationDirectory, ext);
            using (var destination = new FileStream(destinationPath, FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (var source = new FileStream(files[i], FileMode.Open))
                    {
                        using (var gzipStream = new GZipStream(source, CompressionMode.Decompress))
                        {
                            while (true)
                            {
                                int bytesRead = gzipStream.Read(buffer, 0, buffer.Length);
                                if (bytesRead == 0)
                                {
                                    break;
                                }

                                destination.Write(buffer, 0, bytesRead);
                            }   
                        }
                    }
                }   
            }
        }
    }
}