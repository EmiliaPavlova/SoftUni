﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videos.Data;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VideosDbContext();
            Console.WriteLine(context.Videos.Count());
        }
    }
}