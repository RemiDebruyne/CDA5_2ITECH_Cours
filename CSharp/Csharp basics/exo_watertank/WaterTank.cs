using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exo_watertank;

public class WaterTank
{
    public static int TotalVolume => WaterTanks.Select(w => w.Filling).Sum();

    public static List<WaterTank> WaterTanks { get; set; } = [];

    private int _filling;

    public int Weight { get; set; }

    public int Capacity { get; set; }


    public int Filling
    {
        get => _filling;
        set
        {
            if (value > Capacity) _filling = Capacity;
            else if (value < 0) _filling = 0;
            else _filling = value;
        }
    }

    public WaterTank()
    {
        WaterTanks.Add(this);
    }

    public int GetTotalWeight()
    {
        return Weight + Filling;
    }

    public void AddWater(int quantity)
    {
        Filling += quantity;
    }

    public void RemoveWater(int quantity)
    {
        Filling -= quantity;
    }
}
