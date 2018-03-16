namespace CometTailSimulator.Classes
{
    class DataModelComet
    { 
        private double initialSpeed;                  //the speed the particles have because of the pressure in the comet in meters p/s
        private double rotationPeriod;                //the period comet needs to rotate around its axis
        private double densityOfVisualisation;        //the angle between the lines reprezenting a new layer
        private double activeSectionWidth;            //the width in degrees of the more active part of the comet
        private double nightCoefficient;              //the ratio between the number of particles from the dark and bright side
        private double activeRegionCoefficient;       //the ratio between the number of particles on the more active and the rest regions
        private double minimumSize;                   //the minimum size of a particle in microns
        private double maximumSize;                   //the maximum size of a particle in microns
        private int numberOfParticlesPerLine;         //the number which shoud be ejected if it is in a normal region

        DataModelComet(double initSpeed, double rotation, double density, double activeS, double nightC,double activeC,int numOfParticles, double max, double min)
        {
            this.InitialSpeed = initSpeed;
            this.RotationPeriod = rotation;
            this.DensityOfVisualisation = density;
            this.ActiveSectionWidth = activeS;
            this.NightCoefficient = nightC;
            this.ActiveRegionCoefficient = activeC;
            this.NumberOfParticlesPerLine = numOfParticles;
            this.MaximumSize = max;
            this.MinimumSize = min;
        }

        public double InitialSpeed { get => initialSpeed; private set => initialSpeed = value; }
        public double RotationPeriod { get => rotationPeriod; private set => rotationPeriod = value; }
        public double DensityOfVisualisation { get => densityOfVisualisation; private set => densityOfVisualisation = value; }
        public double ActiveSectionWidth { get => activeSectionWidth; private set => activeSectionWidth = value; }
        public double NightCoefficient { get => nightCoefficient; private set => nightCoefficient = value; }
        public double ActiveRegionCoefficient { get => activeRegionCoefficient; private set => activeRegionCoefficient = value; }
        public int NumberOfParticlesPerLine { get => numberOfParticlesPerLine; private set => numberOfParticlesPerLine = value; }
        public double MinimumSize { get => minimumSize; private set => minimumSize = value; }
        public double MaximumSize { get => maximumSize;private set => maximumSize = value; }
    }
}
