using TransportApi.Domain.Entities;

namespace TransportApi.Application.Dto;

public class UpdateTransportDto
{
    public int Id { get; set; }

    public TransportMode Mode { get; set; }

    public int DistanceKm { get; set; }

    public int EmissionFactor { get; set; }
}
