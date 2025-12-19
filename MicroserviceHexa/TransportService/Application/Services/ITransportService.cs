using TransportApi.Application.Dto;

namespace TransportApi.Application.Services;

public interface ITransportService
{
    Task<List<TransportResponseDto>> GetAllAsync();

    Task<TransportResponseDto> GetByIdAsync(int id);

    Task<int> GetEmissionByTransport(int transportId);

    Task<TransportResponseDto> AddAsync(CreateTransportDto createTransportDto);

    Task UpdateAsync(UpdateTransportDto updateTransportDto);
}
