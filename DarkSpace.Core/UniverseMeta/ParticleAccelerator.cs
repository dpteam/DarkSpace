using System;
using System.Collections.Generic;

namespace DarkSpace.UniverseMeta
{
    public class ParticleAccelerator
    {
        private readonly List<Particle> particles = new(); // список всех частиц
        private readonly double timeStep = 0.01; // размер шага при моделировании
        
        public void AddParticle(Particle p)
        {
            particles.Add(p);
        }

        public void RunSimulation(int numSteps)
        {
            for (int i = 0; i < numSteps; i++)
            {
                foreach (Particle p in particles)
                {
                    // вычисляем силы, действующие на частицу
                    double ax = 0;
                    double ay = 0;

                    foreach (Particle other in particles)
                    {
                        if (other != p)
                        {
                            double dx = other.X - p.X;
                            double dy = other.Y - p.Y;
                            double r = Math.Sqrt(dx * dx + dy * dy);
                            double f = (p.Charge * other.Charge) / (r * r); // закон Кулона

                            ax += f * dx / r;
                            ay += f * dy / r;
                        }
                    }

                    // вычисляем новое положение и скорость частицы
                    p.VX += ax * timeStep / p.Mass;
                    p.VY += ay * timeStep / p.Mass;
                    p.X += p.VX * timeStep;
                    p.Y += p.VY * timeStep;
                }
            }
        }
    }
}