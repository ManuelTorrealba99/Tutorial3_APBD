namespace Tutorial3_APBD.model;

public class ContainerShip
{
    public List<Container> Containers { get; set; } = new();
    public double MaxWeight { get; }
    public int MaxContainers { get; }
    public double MaxSpeed { get; }

    public ContainerShip(double maxWeight, int maxContainers, double maxSpeed)
    {
        MaxWeight = maxWeight;
        MaxContainers = maxContainers;
        MaxSpeed = maxSpeed;
    }
    
    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
            throw new InvalidOperationException("Ship is at full container capacity.");
        double totalWeight = Containers.Sum(c => c.CargoMass + c.TareWeight) + container.CargoMass + container.TareWeight;
        if (totalWeight > MaxWeight * 1000)
            throw new InvalidOperationException("Ship exceeds maximum weight capacity.");
        Containers.Add(container);
    }
    
    public void RemoveContainer(string serialNumber)
    {
        Container container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException("Container not found on the ship.");
        
        Containers.Remove(container);
    }

    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        Container container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException("Container not found on this ship.");
        
        targetShip.LoadContainer(container);
        Containers.Remove(container);
    }
    
    public override string ToString() => $"Ship: {Containers.Count}/{MaxContainers} containers, Speed: {MaxSpeed} knots";

}