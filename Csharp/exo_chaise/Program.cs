using exo_chaise;List<Chair> chairs = [new Chair(4, "wood", "brown"), new Chair(2, "plastic", "white"), new Chair(1, "metal", "gray")];

int loop = 1;

foreach(var chair in chairs)
{
    Console.WriteLine($"chair number : {loop}");
    Console.WriteLine(chair);
    loop++;
}