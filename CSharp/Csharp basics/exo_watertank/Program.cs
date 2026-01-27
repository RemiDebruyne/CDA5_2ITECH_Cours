using exo_watertank;

var tank1 = new WaterTank()
{
    Capacity = 20,
    Filling = 0,
    Weight = 5
};

var tank2 = new WaterTank()
{
    Capacity = 10,
    Filling = 0,
    Weight = 1,
};

Console.WriteLine($"Total weight water tank 1 : {tank1.GetTotalWeight()}");
Console.WriteLine($"Total weight water tank 2 : {tank2.GetTotalWeight()}");
Console.WriteLine("----------------------------------------------------");
Console.WriteLine($"Water quantity in tank 1 : {tank1.Filling}");
Console.WriteLine($"Water quantity in tank 2 : {tank2.Filling}");
Console.WriteLine($"Total quantity of water in all tnaks : {WaterTank.TotalVolume}");

tank1.AddWater(5);
tank2.AddWater(15);

Console.WriteLine($"Quantity of water in tank 1 after adding 5 liters : {tank1.Filling}/{tank1.Capacity}");
Console.WriteLine($"Quantity of water in tank 2 after adding 15 liters : {tank2.Filling}/{tank2.Capacity}");

tank1.RemoveWater(5);
tank2.RemoveWater(1);

Console.WriteLine($"Quantity of water in tank 1 after removing 5 liters : {tank1.Filling}");
Console.WriteLine($"Quantity of water in tank 2 after removing 1 liters : {tank2.Filling}");

Console.WriteLine($"Total quantity in all tanks : {WaterTank.TotalVolume}");