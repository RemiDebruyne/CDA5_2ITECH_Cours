using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace Utilities.Request
{
    public class PizzaRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PizzaType Type { get; set; }

        public List<int> IngredientsId { get; set; }
    }
}
