using DarkSpace.UniverseObjects;
using System.Numerics;

namespace DarkSpace.Server.Tasks
{
    public class BlackHoleTask
    {
        public static class Constants
        {
            public const double G = 6.67430e-11; // гравитационная постоянная
            public const double SpeedOfLight = 299792458; // скорость света м/с
        }

        public async Task SimulateAsync(BlackHole blackHole, double timeInSeconds)
        {
            double timeStep = 0.01;
            double currentTime = 0;

            Vector2 position = new(0, 0);
            Vector2 velocity = new(0, 0);

            while (currentTime < timeInSeconds)
            {
                //Vector2 acceleration = GetAccelaration(blackHole, position);
                //velocity += acceleration * timeStep;
                //position += velocity * timeStep;
                currentTime += timeStep;

                //Console.WriteLine($"Time: {currentTime:F2} s, Distance from Black Hole: {position.Magnitude():F2} m");

                await Task.Delay(100);
            }
        }
        /*
        private static Vector2 GetAccelaration(BlackHole blackHole, Vector2 position)
        {
            double r = position.Magnitude();
            const double Magnitude = Constants.G * blackHole.Mass / Math.Pow(r, 3);
            return Constants.G * blackHole.Mass / Math.Pow(r, 3) * position * -1;
        }
        */
    }
}