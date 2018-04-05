﻿using EphemerisCalculator.Classes;
using System;

namespace EphemerisCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //SHWASSMAN WACHMAN  -  12756   5.722
            //ASASSN1 - 34 496   1.4987
             Console.WriteLine("Enter initial velocity, velocity Angle, sun Angle and distance each on a separate line");
              var velocity = double.Parse(Console.ReadLine());
              var velocityAngle = double.Parse(Console.ReadLine());
              var sunAngle = double.Parse(Console.ReadLine()); 
              var distance = double.Parse(Console.ReadLine());


              CalculationManager manager = new CalculationManager(velocity, velocityAngle, sunAngle, distance);

              Console.WriteLine("Write the duration in days");

              manager.CalculateAndSave(int.Parse(Console.ReadLine()));
              
          //  Console.WriteLine(Math.Atan2(2, -1)*180/Math.PI);
        }
    }
}
