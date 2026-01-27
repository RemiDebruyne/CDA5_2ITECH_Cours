using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_shape.Shapes;

public class Square : Shape
{
    public int Side { get; set; }

    public override string ToString()
    {
        return $"Square side : {Side}";
    }
}
