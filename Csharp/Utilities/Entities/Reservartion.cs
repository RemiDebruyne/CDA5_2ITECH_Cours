using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities.AdoEntities;

namespace Utilities.Entities;

public class Reservartion : Entity
{
    public ReservationStatus Status { get; set; }
    public Room Room { get; set; }

    public int RoomId { get; set; }
    public HotelClient Client { get; set; }

    public int ClientId { get; set; }
}

public enum ReservationStatus
{
    Booked,
    Ongoing,
    Done,
    Canceled
}
