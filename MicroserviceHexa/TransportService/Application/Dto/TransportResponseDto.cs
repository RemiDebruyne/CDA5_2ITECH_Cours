using TransportApi.Domain.Entities;

namespace TransportApi.Application.Dto;

public class TransportResponseDto
{
    public int Id { get; set; }

    public string Mode { get; set; }

    public int DistanceKm { get; set; }

    public int EmissionFactor { get; set; }

    public static TransportResponseDto FromTransport(Transport transport)
    {
        return new TransportResponseDto
        {
            Id = transport.Id,
            Mode = transport.Mode.ToString(),
            DistanceKm = transport.DistanceKm,
            EmissionFactor = transport.EmissionFactor,
        };
    }
}
