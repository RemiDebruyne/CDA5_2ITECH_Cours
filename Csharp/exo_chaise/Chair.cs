using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_chaise;

public class Chair
{
    public int FeetCount { get; set; }
    public string Material {  get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        return $"FeetCount : {FeetCount} \n" +
            $"Material : {Material} \n" +
            $"Color : {Color} \n";
    }

    public Chair()
    {
        
    }

    public Chair(int feetCount, string material, string color)
    {
        FeetCount = feetCount;
        Material = material;
        Color = color;
    }
}
