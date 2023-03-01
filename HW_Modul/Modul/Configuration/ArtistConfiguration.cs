using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul.Configuration
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Phone).HasMaxLength(12);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.InstagramUrl).HasMaxLength(50);

            builder.HasData(new List<Artist>()
                {
                    new Artist() { Id = -1, Name = "Sanah", DateOfBirth = new DateTime(1997, 9, 2), InstagramUrl = "https://www.instagram.com/sanahmusic/" },
                    new Artist() { Id = -2, Name = "Sobel", DateOfBirth = new DateTime(2001, 11, 22) },
                    new Artist() { Id = -3, Name = "Dawid Podsiadlo", DateOfBirth = new DateTime(1993, 5, 23), InstagramUrl = "https://www.instagram.com/dylanwishop/" },
                    new Artist() { Id = -4, Name = "Khayat", DateOfBirth = new DateTime(1997, 4, 3), InstagramUrl = "https://www.instagram.com/ado.khayat/", Phone = "380687618160" },
                    new Artist() { Id = -5, Name = "SadSvit", DateOfBirth = new DateTime(2004, 5, 1), InstagramUrl = "https://www.instagram.com/sadsvit/", Email = "sadsvitmusic@gmail.com" }
                });
        }
    }
}
