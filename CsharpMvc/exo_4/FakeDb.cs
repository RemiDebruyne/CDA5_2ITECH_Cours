using exo_4.Models;

namespace exo_4;

public class FakeDb
{
    public List<Product> Products { get; set; } = [
            new(){
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = 1,
                Stock = 0,
            }
        ];
}
