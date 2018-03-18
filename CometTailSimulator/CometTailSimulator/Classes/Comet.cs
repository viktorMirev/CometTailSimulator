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

        public double X { get => x; private set => x = value; }
        public double Y { get => y; private set => y = value; }

        public Comet(DataModelComet model)
        {
            this.cometData = model;
            this.daysAfterTheStart = 0;
            this.rotationAngle = 0.0;
        }
        public void Update(DataModel data)
        {
            this.elong = data.SunAngle;

            double dX = data.Distance * (Math.Cos(elong * Math.PI / 180));
            double dY = data.Distance * (Math.Sin(elong * Math.PI / 180));

            this.X = Constants.centralMassX - dX;
            this.Y = Constants.centralMassY + dY;

            this.velocityAngle = data.VelocityAngle;
            this.velositySpeed = data.VelocitySpeed;
            //updating the angle of the comet according to the distant stars

            this.rotationAngle += 360* Constants.dayInS / (cometData.RotationPeriod * 86400);
            this.rotationAngle %= 360;
            daysAfterTheStart++;
        }
        private void AddNewLine(List<Particle> allParticles, double angle, bool isActive, bool isDark)
        {
            
            
           double coefficient = 1;                                                  //
           if (isActive) coefficient *= this.cometData.ActiveRegionCoefficient;     // calculating the overallcoefficient
           if (isDark) coefficient   *= this.cometData.NightCoefficient;            //

           int numberOfParticles = (int)(this.cometData.NumberOfParticlesPerLine * coefficient);


            //convert to radians
            //angle *= (Math.PI / 180);

            for (double i = cometData.MinimumSize; i < cometData.MaximumSize; i += Constants.sizeStep)
            {
                
                var expCoeff = Constants.distrCoef * Math.Pow(i, Constants.powLawIndex);
                var currNum = (int)(numberOfParticles * expCoeff);       //exponential implementation

                var angleStep = 2 * Constants.diffraction / currNum;

                angle -= Constants.diffraction;

                for (int j = 0; j < currNum; j++)
                {
                    //POSSIBLE IDIOTISM
                    Velocity vectorFromEjection = new Velocity(Math.Cos(angle * Math.PI / 180) * cometData.InitialSpeed * Constants.dayInS / Constants.scale, -Math.Sin(angle * Math.PI / 180) * (cometData.InitialSpeed * Constants.dayInS / Constants.scale));
                    Velocity vectorFromCometVelocity = new Velocity(Math.Cos(this.velocityAngle * Math.PI / 180) * this.velositySpeed * Constants.dayInS / Constants.scale, -Math.Sin(this.velocityAngle * Math.PI / 180) * (this.velositySpeed * Constants.dayInS / Constants.scale));

                    vectorFromCometVelocity.Add(vectorFromEjection);

                    Velocity finalVelocity = vectorFromCometVelocity;

                    allParticles.Add(new Particle(this.X, this.Y, i, finalVelocity));

                    angle += angleStep;
                }
                

            }
          
        }
        public void AddNewLayer(List<Particle> allParticles, List<KeyValuePair<int,int>> cometTrail)
        {
            cometTrail.Add(new KeyValuePair<int, int>((int)this.X, (int)this.Y));

           
            var numOfLines = (int)(360 / this.cometData.DensityOfVisualisation);
            var currAngle = 0.0;

           
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
