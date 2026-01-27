using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities;

public class Pizza : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public PizzaType Type { get; set; }
    public List<Ingredient> Ingredients { get; set; }

}

public enum PizzaType
{
    Vege,
    Spicy
}
