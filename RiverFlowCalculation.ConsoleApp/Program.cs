using System;
using System.Collections.Generic;
using RiverFlowCalculation.ConsoleApp.Models;

namespace RiverFlowCalculation.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start of the console");
            Console.WriteLine();

            var testData = new List<RiverCrossSectionPart>
            {
                new RiverCrossSectionPart(2.0, 2.0, 5, 0.3),
                new RiverCrossSectionPart(2.0, 4.7, 7, 0.7),
                new RiverCrossSectionPart(2.0, 5.0, 8),
                new RiverCrossSectionPart(2.0, 3.2, 6, 0.6)
            };

            var data = new RiverCrossSection(testData);

            Console.WriteLine($"Total discharge for the river flow is {data.GetTotalDischarge()} m3/s");

            Console.WriteLine();
            Console.WriteLine("End of the console. Press any key to close this window");
            Console.ReadKey();
        }
    }
}