using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_shape.Shapes;

public abstract class Shape : IMovable
{
    public Point Origin { get; set; }

    public void Move(double x, double y)
    {
        Origin = new Point()
        {
            X = x,
            Y = y
        };
    }
}
