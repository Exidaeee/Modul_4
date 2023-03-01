using Microsoft.EntityFrameworkCore;
using Modul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul.Configuration
{
    public class GenreConfigurations : IEntityTypeConfiguration<Genre>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Title).HasMaxLength(50);

            builder.HasData(new List<Genre>()
                {
                   new Genre(){ Id = -1, Title = "Rock"},
                   new Genre(){ Id = -2, Title = "Pop" },
                   new Genre(){ Id = -3, Title = "Hip Hop"},
                   new Genre(){ Id = -4, Title = "Jahz" },
                   new Genre(){ Id = -5, Title = "Indie" }
                });
        }
    }
}
