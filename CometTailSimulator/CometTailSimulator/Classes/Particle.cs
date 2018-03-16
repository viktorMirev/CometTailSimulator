using System;

namespace CometTailSimulator.Classes
{
    class Particle
    {
        private double x;
        private double y;
        private Velocity vector;
        private double size;

        public Particle(double x, double y, double size,Velocity vector)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.vector = vector;
        }
        private double DistanceTo(double x, double y)
        {
            return Math.Sqrt((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y));
        }

        private double dX()        //pixel differense in the x of the sun and the particle
        {
            return this.x - Constants.centralMassX;
        }

        private double dY()        //pixel differense in the y of the sun and the particle
        {
            return this.y - Constants.centralMassY;
        }

        private Velocity CalculateSunVector()
        {
            double distance = this.DistanceTo(Constants.centralMassX, Constants.centralMassY); // distance to the Sun
            double acc = ((3 / 16) * (1 + Constants.A) * Constants.L) /
                (Math.PI * Constants.c * Constants.p * this.size * Constants.micron * (distance * Constants.scale) * (distance * Constants.scale));
            //acceleration formula in the description

            double vectorLenInPix = acc * Constants.dayInS / Constants.scale; //the lenght of the new vector in pixels;

            double sunVectorX = vectorLenInPix * dX() / distance;
            double sunVectorY = vectorLenInPix * dY() / distance;

            return new Velocity(sunVectorX, sunVectorY);
        }

        public void Update()
        {
            this.vector.Add(CalculateSunVector());
            this.x += this.vector.X;
            this.y += this.vector.Y;
        }


    }
}
