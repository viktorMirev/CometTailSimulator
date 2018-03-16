using System;
using System.Collections.Generic;

namespace CometTailSimulator.Classes
{
    class Comet
    {
        private double x;
        private double y;
        private double elong;                     // sun angle
        private double velocityAngle;
        private double velositySpeed;             //how fast the comet was moving
        private double rotationAngle;             //represents the angle of rotation relative to the distant stars
        private int daysAfterTheStart;            //the number of days that have passed since the beginning of the simulation
        private DataModelComet cometData;         //holds all the data needed
        public Comet(DataModelComet model)
        {
            this.cometData = model;
        }
        public void Update(DataModel data)
        {
            this.elong = data.SunAngle;

            double dX = data.Distance * (Math.Cos(elong * Math.PI / 180));
            double dY = data.Distance * (Math.Sin(elong * Math.PI / 180));

            this.x = Constants.centralMassX - dX;
            this.y = Constants.centralMassY + dY;

            this.velocityAngle = data.VelocityAngle;
            this.velositySpeed = data.VelocitySpeed;
            //updating the angle of the comet according to the distant stars

            this.rotationAngle = 360 * (this.daysAfterTheStart % this.cometData.RotationPeriod);
        }
        private void AddNewLine(List<Particle> allParticles, double angle, bool isActive, bool isDark)
        {
            double coefficient = 1;
            if (isActive) coefficient *= this.cometData.ActiveRegionCoefficient;
            if (isDark) coefficient   *= this.cometData.NightCoefficient;

            int numberOfParticles = (int)(this.cometData.NumberOfParticlesPerLine * coefficient);

            //in radians
            angle *= (Math.PI / 180);

            Velocity vectorFromEjection = new Velocity(Math.Cos(angle)*cometData.InitialSpeed/Constants.scale, -Math.Sin(angle) * (cometData.InitialSpeed / Constants.scale));
            Velocity vectorFromCometVelocity = new Velocity(Math.Cos(this.velocityAngle) * this.velositySpeed / Constants.scale, Math.Sin(this.velocityAngle) * (this.velositySpeed / Constants.scale));

            Velocity finalVelocity = vectorFromCometVelocity.Add(vectorFromEjection);

            double currSize = cometData.MinimumSize;

            while (currSize<=cometData.MaximumSize)
            {
                
                currSize += 0.3;
            }

        }
        public void AddNewLayer(List<Particle> allParticles)
        {
            var numOfLines = (int)(360 / this.cometData.DensityOfVisualisation);
            var currAngle = 0.0;

            //DA SA NQKOLKO I DA IMA KRAGCHE s malki deto e s povisheno density i golqmo naprimer
            for (int i = 0; i < numOfLines; i++)
            {
                bool isActive = false;                        //flags if we are in the active region
                bool isDark = false;                          //flags if we are in the dark region

                double offSet = this.rotationAngle;

                if ((currAngle - offSet) >= 0 && (currAngle - offSet) <= (this.cometData.ActiveSectionWidth))
                {
                    isActive = true;
                }

                offSet = this.elong;

                if (Math.Cos((currAngle - offSet) * Math.PI / 180) < 0)
                {
                    isDark = true;
                }

                AddNewLine(allParticles, currAngle, isActive, isDark);

                currAngle += cometData.DensityOfVisualisation;

            }
        }


    }
}
