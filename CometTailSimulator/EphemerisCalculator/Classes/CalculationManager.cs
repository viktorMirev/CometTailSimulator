using CometTailSimulator.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EphemerisCalculator.Classes
{
    class CalculationManager
    {
        private Orbiter comet;
        private IList<DataModel> ephemeris;
        public CalculationManager(double velocity,double velocityAngle, double angle, double distance)
        {
            distance*=(Constants.AU / Constants.scale);
            var x = Constants.centralMassX - distance * Math.Cos((angle/180) * Math.PI );
            var y = Constants.centralMassY + distance * Math.Sin((angle/180) * Math.PI );

            var vX = velocity * Math.Cos(velocityAngle * Math.PI);
            var vY = velocity * Math.Sin(velocityAngle * Math.PI);
            Velocity vector = new Velocity(vX / Constants.scale, vY / Constants.scale);

            comet = new Orbiter(x, y, vector, angle);
            ephemeris = new List<DataModel>();
        }

        public void CalculateAndSave(int duration)
        {
  
            var allItterations = Constants.accuracyOfeph * duration;

            var flagger = 0;
            for (int i = 0; i < allItterations; i++)
            {
                comet.Update();
                if (flagger==Constants.accuracyOfeph-1)
                {
                    flagger = 0;

                    double velocity = Math.Sqrt(comet.Vector.X * comet.Vector.X + comet.Vector.Y * comet.Vector.Y)*Constants.scale;
                    double velocityAngle = Math.Atan2(comet.Vector.X, -comet.Vector.Y) *180/Math.PI;
                    if (velocityAngle < 0) velocityAngle += 360;

                    ephemeris.Add(new DataModel(comet.DistanceToSun(), comet.Angle,velocityAngle, velocity));

                    continue;   
                }
                flagger++;

            }
            Print();
        }
        private void Print()
        {
            StringBuilder output = new StringBuilder();
            foreach (var item in this.ephemeris)
            {
                output.AppendLine(item.ToString());
            }
            File.WriteAllText("data.txt", output.ToString());
        }
            

        
    }
}
