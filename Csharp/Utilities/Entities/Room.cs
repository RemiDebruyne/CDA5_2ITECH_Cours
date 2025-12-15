using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities;

public class Room : Entity
{
    public RoomStatus status { get; set; }
    public int BedCount { get; set; }
    public int Price { get; set; }

    public List<Reservartion> Reservartions { get; set; }
}

public enum RoomStatus
{
    Available,
    Booked,
    Cleaning,
}
