using DarkSpace.UniverseMeta;

internal class ParticleAcceleratorTask
{
    public static async Task ParticleAcceleratorTaskDoAsync()
    {
        Particle p1 = new(0, 0, 0, 0, 1, 1);
        Particle p2 = new(1, 0, 0, 0, 1, -1);

        ParticleAccelerator accelerator = new();
        accelerator.AddParticle(p1);
        accelerator.AddParticle(p2);
        
        await Task.Run(() => accelerator.RunSimulation(100));

        Console.WriteLine("p1: ({0}, {1})", p1.X, p1.Y);
        Console.WriteLine("p2: ({0}, {1})", p2.X, p2.Y);
    }
}