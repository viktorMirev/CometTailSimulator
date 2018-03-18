using EphemerisCalculator.Classes;
using System;

namespace EphemerisCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter initial velocity, velocity Angle, sun Angle and distance each on a separate line");
            var velocity = double.Parse(Console.ReadLine());
            var velocityAngle = double.Parse(Console.ReadLine());
            var sunAngle = double.Parse(Console.ReadLine()); 
            var distance = double.Parse(Console.ReadLine());


            CalculationManager manager = new CalculationManager(velocity, velocityAngle, sunAngle, distance);

            Console.WriteLine("Write the duration in days");

            manager.CalculateAndSave(int.Parse(Console.ReadLine()));
        }
    }
}
