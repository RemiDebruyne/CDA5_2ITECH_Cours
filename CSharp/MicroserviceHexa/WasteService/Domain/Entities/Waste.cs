namespace WasteApi.Domain.Entities;

public class Waste
{
    public int Id { get; set; }

    public WasteType WasteType { get; set; }

    public int Quantity { get; set; }

    public int RecyclingRate { get; set; }
}

public enum WasteType
{
    Plastic,
    Paper,
    Organic,
}
