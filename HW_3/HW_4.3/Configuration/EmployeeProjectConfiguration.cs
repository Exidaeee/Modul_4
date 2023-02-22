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
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasKey(k => k.EmployeeProjectId);
            builder.Property(p => p.Rate).HasColumnType("money");
            builder.Property(p => p.StartedDate).HasColumnType("datetime2");
        }
    }
}
