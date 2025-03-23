namespace Tutorial3_APBD.model;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }
    
    public GasContainer(double pressure, double maxPayload, double tareWeight, int height, int depth)
        : base(height, tareWeight, depth, "G", maxPayload)
    {
        Pressure = pressure;
    }

    public override void EmptyCargo() => CargoMass *= 0.05;
    
    public void NotifyHazard(string msg) => Console.WriteLine($"[HAZARD] {SerialNumber}: {msg}");
}