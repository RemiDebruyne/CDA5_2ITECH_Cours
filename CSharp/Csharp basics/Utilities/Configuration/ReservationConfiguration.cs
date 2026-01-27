using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;
using Utilities.Entities.AdoEntities;

namespace Utilities.Configuration;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservartion>
{
    public void Configure(EntityTypeBuilder<Reservartion> builder)
    {
        builder
            .HasOne(reservation => reservation.Room)
            .WithMany(room => room.Reservartions)
            .HasForeignKey(reservation => reservation.RoomId);

        builder
            .HasOne(reservation => reservation.Client)
            .WithMany(client => client.Reservartions)
            .HasForeignKey(reservation => reservation.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
