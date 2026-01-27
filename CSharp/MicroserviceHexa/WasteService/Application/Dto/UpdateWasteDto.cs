using WasteApi.Domain.Entities;

namespace WasteApi.Application.Dto;

public class UpdateWasteDto
{
    public int Id { get; set; }

    public WasteType WasteType { get; set; }

    public int Quantity { get; set; }

    public int RecyclingRate { get; set; }
}
