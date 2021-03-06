﻿namespace CometTailSimulator.Classes
{
    public abstract class Constants
    {
        public static readonly int centralMassX = 100;              //the x coordinate of the sun
        public static readonly int centralMassY = 100;              //the y coordinate of the sun
        public static readonly double c = 300000000;                //the speed of light
        public static readonly double L = 3.828 * (1e26);           //the luminosity of the sun
        public static readonly double AU = 149600000000;            //the distance between The Earth & the sun
        public static readonly double A = 0.5;                      //the AVG albedo of the particles
        public static readonly double p = 1500;                     //the AVG density of the particles
        public static readonly double dayInS = 7200;                //the number of seconds in a day //currently 24 hours
        public static readonly int scale = 26000000;                //meters per pixl 40 000 000
        public static readonly double micron = 1 * (1e-6);          //micron
        public static readonly double sizeStep = 0.1;               //what is the difference in the sizes of two diff types os particles in microns
        public static readonly double powLawIndex = -3.5;           //the size distribution function is characterized by the power law index of −3.5.
        public static readonly double distrCoef = 10;               //the coefficient in front of the formula for the size distr
        public static readonly double diffraction = 1.5;            //the +- angle when creating a line
        public static readonly double SolarMass = 2 * (1e30);       //solar mass
        public static readonly double G = 6.67 * (1e-11);           //gravity constant
        public static readonly double accuracyOfeph = 10;           // 1/accOfeph is the delta period of the ephemeris simulation
        public static readonly int pixelXoffSet = 1500;             //how to offset the bitmap       
        public static readonly int pixelYoffSet = 1000;             //same but for Y
    }                                                            
}                                                                
                                                                 