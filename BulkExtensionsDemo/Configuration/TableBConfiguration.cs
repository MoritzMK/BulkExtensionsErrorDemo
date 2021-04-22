using BulkExtensionsDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkExtensionsDemo.Configuration
{
    public class TableBConfiguration : IEntityTypeConfiguration<TableB>
    {
        public void Configure(EntityTypeBuilder<TableB> builder)
        {
            builder.ToTable("TabelleB", "Stammdaten");

            builder.HasKey(p => p.Id).HasName("PK_TabelleB");
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Description).HasColumnName("Beschreibung");
        }
    }
}