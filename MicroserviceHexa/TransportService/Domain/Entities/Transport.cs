namespace TransportApi.Domain.Entities;

public class Transport
{
    public int Id { get; set; }
    
    public TransportMode Mode { get; set; }

    public int DistanceKm {  get; set; }

    public int EmissionFactor { get; set; }
}

public enum TransportMode
{
    Car,
    Bus,
    Bike,
    Train
}