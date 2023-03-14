namespace DarkSpace.UniverseMeta
{
    public class Particle
    {
        public double X { get; set; } // координата частицы по оси x
        public double Y { get; set; } // координата частицы по оси y
        public double VX { get; set; } // скорость частицы по оси x
        public double VY { get; set; } // скорость частицы по оси y
        public double Mass { get; set; } // масса частицы
        public double Charge { get; set; } // заряд частицы

        public Particle(double x, double y, double vx, double vy, double mass, double charge)
        {
            X = x;
            Y = y;
            VX = vx;
            VY = vy;
            Mass = mass;
            Charge = charge;
        }
    }
}
