using TransportApi.Application.Dto;
using TransportApi.Domain.Entities;
using TransportApi.Domain.Ports;
using TransportApi.Infrastructure.Repository;

namespace TransportApi.Application.Services;

public class TransportService(ITransportRepository repository) : ITransportService
{

    public async Task<TransportResponseDto> AddAsync(CreateTransportDto createTransportDto)
    {
        var transport = await repository.AddAsync(new Transport()
        {
            Mode = createTransportDto.Mode,
            DistanceKm = createTransportDto.DistanceKm,
            EmissionFactor = createTransportDto.EmissionFactor
        });

        return TransportResponseDto.FromTransport(transport);
    }

    public async Task<List<TransportResponseDto>> GetAllAsync()
    {
        var transports = await repository.GetAllAsync();

        return [.. transports.Select(t => TransportResponseDto.FromTransport(t))];
    }

    public async Task<TransportResponseDto> GetByIdAsync(int id)
    {
        var transport = await repository.GetByIdAsync(id);

        if (transport is null)
        {
            return null;
        }

        return TransportResponseDto.FromTransport(transport);
    }

    public async Task<int> GetEmissionByTransport(int transportId)
    {
        var transport = await GetByIdAsync(transportId) ?? throw new Exception();

        return transport.DistanceKm * transport.EmissionFactor;
    }

    public async Task UpdateAsync(UpdateTransportDto updateTransportDto)
    {
        await repository.Update(updateTransportDto.Id, new Transport()
        {
            Mode = updateTransportDto.Mode,
            Id = updateTransportDto.Id,
            DistanceKm = updateTransportDto.DistanceKm,
            EmissionFactor = updateTransportDto.EmissionFactor
        });
    }
}
