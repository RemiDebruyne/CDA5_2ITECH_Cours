using TransportApi.Domain.Entities;

namespace TransportApi.Application.Dto;

public class CreateTransportDto
{
    public TransportMode Mode { get; set; }

    public int DistanceKm { get; set; }

    public int EmissionFactor { get; set; }
}
