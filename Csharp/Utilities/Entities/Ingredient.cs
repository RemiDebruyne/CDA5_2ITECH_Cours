using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities
{
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Pizza> Pizzas { get; set; }
    }
}
