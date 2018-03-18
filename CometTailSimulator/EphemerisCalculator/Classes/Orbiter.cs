using CometTailSimulator.Classes;
using System;

namespace EphemerisCalculator.Classes
{
    class Orbiter
    {
        private double x;
        private double y;
        private Velocity vector;
        private double angle;
        public double X { get => x; private set => x = value; }
        public double Y { get => y; private set => y = value; }
        public double Angle { get => angle; private set => angle = value; }
        public Velocity Vector { get => vector; private set => vector = value; }

        public Orbiter(double x, double y, Velocity vector, double angle)
        {
            this.X = x;
            this.Y = y;  
            this.Vector = vector;
            this.Angle = angle;
        }
        private double DistanceTo(double x, double y)
        {
            return Math.Sqrt((this.X - x) * (this.X - x) + (this.Y - y) * (this.Y - y));
        }

        public double dX()        //pixel differense in the x of the sun and the particle
        {
            return this.X - Constants.centralMassX;
        }

        public double dY()        //pixel differense in the y of the sun and the particle
        {
            return this.Y - Constants.centralMassY;
        }
        
        public double DistanceToSun()
        {
            double distance = this.DistanceTo(Constants.centralMassX, Constants.centralMassY); // distance to the Sun
            return (distance * Constants.scale / Constants.AU);
        }

        
        private Velocity CalculateGravityVector()
        {
            double distance = this.DistanceTo(Constants.centralMassX, Constants.centralMassY); // distance to the Sun

            //calculating the angle
            this.Angle = Math.Atan2(dY(), dX());
            this.Angle *= (180/Math.PI);
            if (this.Angle < 0) this.Angle += 360;


            double acc = Constants.SolarMass * Constants.G / (distance * Constants.scale * distance * Constants.scale);
            //acceleration formula in the description

            double vectorLenInPix = acc * Constants.dayInS / (Constants.scale*Constants.accuracyOfeph); //the lenght of the new vector in pixels;

            double vectorX = - vectorLenInPix * dX() / distance;
            double vectorY = - vectorLenInPix * dY() / distance;

            return new Velocity(vectorX, vectorY);
        }

        public void Update()
        {
            this.Vector.Add(CalculateGravityVector());
            this.X += this.Vector.X;
            this.Y += this.Vector.Y;
        }


    }
}
