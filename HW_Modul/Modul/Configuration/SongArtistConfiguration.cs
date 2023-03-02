using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul.Configuration
{
    public class SongArtistConfiguration : IEntityTypeConfiguration<SongArtist>
    {
        public void Configure(EntityTypeBuilder<SongArtist> builder)
        {
            builder.HasKey(k => new { k.ArtistId, k.SongId });
            builder.HasOne(r => r.Song)
                .WithMany(r => r.SongArtists)
                .HasForeignKey(r => r.SongId);
            builder.HasOne(r => r.Artist)
                .WithMany(r => r.SongArtists)
                .HasForeignKey(r => r.ArtistId);
            builder.HasData( new List<SongArtist>() 
            { 
                new SongArtist(){ ArtistId = -1, SongId = -2 },
                new SongArtist(){ ArtistId = -1, SongId = -3 },
                new SongArtist(){ ArtistId = -3, SongId = -1 },
                new SongArtist(){ ArtistId = -4, SongId = -4 },
                new SongArtist(){ ArtistId = -5, SongId = -5 }
            });
        }
    }
}
