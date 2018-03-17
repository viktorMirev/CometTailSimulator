using System;

namespace EphemerisCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Atan2(1, 1)*180/Math.PI);  //1
            Console.WriteLine(Math.Atan2(1, -1)*180/Math.PI); //2
            Console.WriteLine(Math.Atan2(-1, -1)*180/Math.PI);//3  
            Console.WriteLine(Math.Atan2(-1, 1) * 180 / Math.PI); //4
        }
    }
}
