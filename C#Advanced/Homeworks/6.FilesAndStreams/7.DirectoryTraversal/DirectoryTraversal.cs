﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7.DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            FileInfo fileInfo = new FileInfo("../../temp.txt");
            DirectoryInfo dir = fileInfo.Directory;
            FileSystemInfo[] fsInfo = dir.GetFileSystemInfos();

            var result = new Dictionary<string, List<string>>();
            foreach (FileSystemInfo info in fsInfo)
            {
                var name = info.Name;
                var regex = @"(.*(\..*))";
                if (Regex.IsMatch(name, regex))
                {
                    var match = Regex.Match(name, regex);
                    if (!result.ContainsKey(match.Groups[2].ToString()))
                    {
                        result.Add(match.Groups[2].ToString(), new List<string>());
                    }

                    result[match.Groups[2].ToString()].Add(match.Groups[1].ToString());
                }
            }

            var sortedResults = result.OrderByDescending(files => files.Value.Count).ThenBy(files => files.Key);

            try
            {
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (var writer = new StreamWriter(desktop))
                {
                    foreach (var extencion in sortedResults)
                    {
                        writer.WriteLine(extencion.Key);
                        extencion.Value.Reverse();
                        foreach (var file in extencion.Value)
                        {
                            writer.WriteLine("--{0}", file);
                        }
                    }
                }

                Console.WriteLine("Ready. Check on your desktop");
            }
            catch (UnauthorizedAccessException)
            {
                foreach (var extencion in sortedResults)
                {
                    Console.WriteLine(extencion.Key);
                    extencion.Value.Sort();
                    foreach (var file in extencion.Value)
                    {
                        Console.WriteLine("--{0}", file);
                    }
                }
            }
        }
    }
}