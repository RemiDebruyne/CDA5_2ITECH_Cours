using WasteApi.Domain.Entities;

namespace WasteApi.Application.Dto;

public class WasteResponseDto
{
    public int Id { get; set; }

    public string WasteType { get; set; }

    public int Quantity { get; set; }

    public int RecyclingRate { get; set; }

    public static WasteResponseDto FromWaste(Waste waste)
    {
        return new WasteResponseDto
        {
            Id = waste.Id,
            WasteType = waste.WasteType.ToString(),
            Quantity = waste.Quantity,
            RecyclingRate = waste.RecyclingRate,
        };
    }
}
