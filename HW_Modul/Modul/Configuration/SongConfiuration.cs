using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Modul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul.Configuration
{
    public class SongConfiuration : IEntityTypeConfiguration<Song>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Title).HasMaxLength(50);
            builder.Property(p => p.Duration).HasColumnType("time");
            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId);
            builder.HasData(new List<Song>()
            {
                   new Song { Id = -1, Title = "Mori", Duration = new TimeSpan(0, 3, 14), ReleasedDate = new DateTime(2022, 10, 21), GenreId = -2 },
                   new Song { Id = -2, Title = "nic dwa razy", Duration = new TimeSpan(0, 3, 9), ReleasedDate = new DateTime(2022, 11, 25), GenreId = -5 },
                   new Song { Id = -3, Title = "szampan", Duration = new TimeSpan(0, 3, 20), ReleasedDate = new DateTime(2020, 5, 8), GenreId = -2 },
                   new Song { Id = -4, Title = "Ultra", Duration = new TimeSpan(0, 4, 0), ReleasedDate = new DateTime(2021, 5, 14), GenreId = -2 },
                   new Song { Id = -5, Title = "Cassette", Duration = new TimeSpan(0, 2, 25), ReleasedDate = new DateTime(2021, 12, 13), GenreId = -1 } 
            });
            
        }
    }
}
