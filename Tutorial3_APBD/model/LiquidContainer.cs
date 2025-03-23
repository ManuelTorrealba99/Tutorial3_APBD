namespace Tutorial3_APBD.model;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    
    public LiquidContainer(bool isHazardous, double maxPayload, double tareWeight, int height, int depth)
        : base(height, tareWeight, depth, "L", maxPayload)
    {
        IsHazardous = isHazardous;
    }
    
    public override void LoadCargo(double mass)
    {
        double capacityLimit = IsHazardous ? 0.5 * MaxPayload : 0.9 * MaxPayload;
        if (CargoMass + mass > capacityLimit)
        {
            NotifyHazard("Hazardous material overfill attempt!");
            throw new InvalidOperationException("HazardousOperationException: Exceeds safety limits.");
        }
        base.LoadCargo(mass);
    }
    
    public void NotifyHazard(string msg) => Console.WriteLine($"[HAZARD] {SerialNumber}: {msg}");
}