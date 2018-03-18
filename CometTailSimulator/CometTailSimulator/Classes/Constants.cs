namespace CometTailSimulator.Classes
{
    public abstract class Constants
    {
        public static readonly int centralMassX = 500;           //the x coordinate of the sun
        public static readonly int centralMassY = 0;           //the y coordinate of the sun
        public static readonly double c = 300000000;           //the speed of light
        public static readonly double L = 3.828 * (10e26);         //the luminosity of the sun
        public static readonly double AU = 149600000000;       //the distance between The Earth & the sun
        public static readonly double A = 0.5;                 //the AVG albedo of the particles
        public static readonly double p = 1.5;                 //the AVG density of the particles
        public static readonly double dayInS = 86400;          //the number of seconds in a day
        public static readonly int scale = 2000000000;          //meters per pixl
        public static readonly double micron = 1 * (10e-6);    //micron
        public static readonly double sizeStep = 0.3;          //what is the difference in the sizes of two diff types os particles in microns
        public static readonly double powLawIndex = -3.5;      //the size distribution function is characterized by the power law index of −3.5.
        public static readonly double distrCoef = 10;          //the coefficient in front of the formula for the size distr
        public static readonly double diffraction = 1.5;       //the +- angle when creating a line
        public static readonly double SolarMass = 2 * (1e30); //solar mass
        public static readonly double G = 6.67 * (1e-11);     //gravity constant
        public static readonly double accuracyOfeph = 5;       // 1/accOfeph is the delta period of the ephemeris simulation
    }
}
