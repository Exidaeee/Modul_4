using HW_4._3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._3.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(k => k.ProjectId);
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Budget).HasColumnType("money");
            builder.Property(p => p.StertedDate).HasColumnType("datetime2");
        }
    }
}
