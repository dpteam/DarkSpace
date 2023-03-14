using Microsoft.VisualBasic;
using System;

namespace DarkSpace.UniverseObjects
{
    public class BlackHole
    {
        public string BlackHoleName { get; set; } = Local.strDefaultBlackHoleName;
        //public int objClass = _star_BlackHole; // Класс тела
        public double Mass { get; set; }
        public double Radius { get; set; }
        public static class Constants
        {
            public const double G = 6.67430e-11; // гравитационная постоянная
            public const double SpeedOfLight = 299792458; // скорость света м/с
        }
        
        public BlackHole(double massInKg)
        {
            Mass = massInKg;
            Radius = 2.0 * Constants.G * Mass / (Math.Pow(Constants.SpeedOfLight, 2));
        }

        public double GetSchwarzschildRadius()
        {
            return 2.0 * Constants.G * Mass / (Math.Pow(Constants.SpeedOfLight, 2));
        }
    }
}
