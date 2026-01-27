using WasteApi.Domain.Entities;

namespace WasteApi.Application.Dto;

public class CreateWasteDto
{
    public WasteType WasteType { get; set; }

    public int Quantity { get; set; }

    public int RecyclingRate { get; set; }
}
