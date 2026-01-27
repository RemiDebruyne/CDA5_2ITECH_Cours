using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace Utilities.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<HotelClient>
    {
        public void Configure(EntityTypeBuilder<HotelClient> builder)
        {
            builder
                .HasMany(client => client.Reservartions)
                .WithOne(reservation => reservation.Client)
                .HasForeignKey(reservation => reservation.ClientId);
        }
    }
}
