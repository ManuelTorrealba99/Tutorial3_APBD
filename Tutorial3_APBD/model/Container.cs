namespace Tutorial3_APBD.model;

public class Container
{
    public double CargoMass { get; protected set; }
    public int Height { get; }
    public double TareWeight { get; }
    public int Depth { get; }
    public string SerialNumber { get; }
    public double MaxPayload { get; }

    private static int serialCounter = 1;

    public Container(int height, double weightTare, int depth, string type, double maxPayload)
    {
        Height = height;
        TareWeight = weightTare;
        Depth = depth;
        SerialNumber = $"KON-{type}-{serialCounter++}";
        MaxPayload = maxPayload;
    }

    public virtual void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaxPayload)
            throw new InvalidOperationException("OverfillException: mass must be less or equal to MaxPayload");
        CargoMass += mass;
    }

    public virtual void EmptyCargo() => CargoMass = 0;
    
    public override string ToString() => $"{SerialNumber}: {CargoMass}kg / {MaxPayload}kg";

}