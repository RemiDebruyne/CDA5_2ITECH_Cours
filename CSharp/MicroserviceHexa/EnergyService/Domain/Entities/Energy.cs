namespace EnergyApi.Domain.Entities;

public class Energy
{
    public int Id { get; set; }
    
    public EnergySource Source { get; set; }

    public int EnergyConsumption { get; set; }

    public DateTime Date { get; set; }
}

public enum EnergySource
{
    Solar,
    Wind,
    Fossile
}
