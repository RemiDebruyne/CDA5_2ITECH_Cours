using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_shape.Shapes;

public class Rectangle : Shape
{
    public int Length { get; set; }
    public int Width { get; set; }

    public override string ToString()
    {
        return $"Rectangle Length : {Length}, Width : {Width}";
    }
}
