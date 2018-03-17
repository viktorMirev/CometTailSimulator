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
        public double X { get => x; private set => x = value / Constants.scale; }
        public double Y { get => y; private set => y = value / Constants.scale; }

        public Orbiter(double x, double y, Velocity vector)
        {
            this.X = x;
            this.Y = y;  
            this.vector = vector;
        }
        private double DistanceTo(double x, double y)
        {
            return Math.Sqrt((this.X - x) * (this.X - x) + (this.Y - y) * (this.Y - y));
        }

        private double dX()        //pixel differense in the x of the sun and the particle
        {
            return this.X - Constants.centralMassX;
        }

        private double dY()        //pixel differense in the y of the sun and the particle
        {
            return this.Y - Constants.centralMassY;
        }

        private Velocity CalculateGravityVector()
        {
            double distance = this.DistanceTo(Constants.centralMassX, Constants.centralMassY); // distance to the Sun

            //calculating the angle
            this.angle = Math.Atan2(dY(), dX());
            this.angle *= (180/Math.PI);
            if (this.angle < 0) this.angle += 360;


            double acc = Constants.SolarMass * Constants.G / (distance * Constants.scale * distance * Constants.scale);
            //acceleration formula in the description

            double vectorLenInPix = acc * Constants.dayInS / (Constants.scale*Constants.accuracyOfeph); //the lenght of the new vector in pixels;

            double vectorX = vectorLenInPix * dX() / distance;
            double vectorY = vectorLenInPix * dY() / distance;

            return new Velocity(vectorX, vectorY);
        }

        public void Update()
        {
            this.vector.Add(CalculateGravityVector());
            this.X += this.vector.X;
            this.Y += this.vector.Y;
        }


    }
}
