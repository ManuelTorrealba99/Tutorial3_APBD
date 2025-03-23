namespace Tutorial3_APBD.model;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }
    private static readonly Dictionary<string, double> RequiredTemperatures = new()
    {
        { "Bananas", 13.3 }, { "Chocolate", 18 }, { "Fish", 2 },
        { "Meat", -15 }, { "Ice Cream", -18 }, { "Frozen Pizza", -30 },
        { "Cheese", 7.2 }, { "Sausages", 5 }, { "Butter", 20.5 }, { "Eggs", 19 }
    };
    
    public RefrigeratedContainer(string productType, double maxPayload, double tareWeight, int height, int depth)
        : base(height, tareWeight, depth, "R", maxPayload)
    {
        if (!RequiredTemperatures.ContainsKey(productType))
            throw new ArgumentException("Invalid product type.");
        ProductType = productType;
        Temperature = RequiredTemperatures[productType];
    }

}