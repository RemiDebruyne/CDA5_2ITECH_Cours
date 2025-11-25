using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_shape.Shapes;

public class Triangle : Shape
{
    public int Base {  get; set; }
    public int Height { get; set; }

    public override string ToString()
    {
        return $"Triangle base : {Base}, height : {Height}";
    }
}
