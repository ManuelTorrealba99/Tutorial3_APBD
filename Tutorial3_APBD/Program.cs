using Tutorial3_APBD.model;

namespace Tutorial3_APBD;

public class Program
{
    public static void Main()
    {
            ContainerShip ship1 = new ContainerShip(50000, 10, 25);
            ContainerShip ship2 = new ContainerShip(60000, 12, 30);

            RefrigeratedContainer bananaContainer = new("Bananas", 10000, 2000, 300, 500);
            LiquidContainer fuelContainer = new(true, 8000, 1500, 250, 400);
            GasContainer heliumContainer = new(200, 5000, 1000, 200, 300);

            Console.WriteLine("Container created:\n" +
                              $"{bananaContainer}\n{fuelContainer}\n{heliumContainer}\n");
            
            bananaContainer.LoadCargo(5000);
            fuelContainer.LoadCargo(3000);
            heliumContainer.LoadCargo(2500);
            
            ship1.LoadContainer(bananaContainer);
            ship1.LoadContainer(fuelContainer);
            ship1.LoadContainer(heliumContainer);

            Console.WriteLine("Container loaded.\n");
            
            Console.WriteLine("Boat Information:");
            Console.WriteLine(ship1);
            foreach (var container in ship1.Containers)
                Console.WriteLine(container);

            ship1.TransferContainer(ship2, bananaContainer.SerialNumber);
            Console.WriteLine("\nContainer tranfer to second boat.\n");

            Console.WriteLine("Boat final state:");
            Console.WriteLine("Boat 1:");
            Console.WriteLine(ship1);
            foreach (var container in ship1.Containers)
                Console.WriteLine(container);

            Console.WriteLine("\nBoat 2:");
            Console.WriteLine(ship2);
            foreach (var container in ship2.Containers)
                Console.WriteLine(container);
        }
}