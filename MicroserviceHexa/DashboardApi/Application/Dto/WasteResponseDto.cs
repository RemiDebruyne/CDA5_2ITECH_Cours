namespace DashboardApi.Application.Dto;

public class WasteResponseDto
{
    public int Id { get; set; }

    public string WasteType { get; set; }

    public int Quantity { get; set; }

    public int RecyclingRate { get; set; }
}
