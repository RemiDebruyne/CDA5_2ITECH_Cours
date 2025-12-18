using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto;
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Category { get; set; }

    public string Description { get; set; }

    public static ProductDto FromProduct(Product product)
    {
        return new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Description = product.Description,
        };
    }
}
