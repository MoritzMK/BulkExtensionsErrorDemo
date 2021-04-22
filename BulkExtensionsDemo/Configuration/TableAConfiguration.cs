using BulkExtensionsDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkExtensionsDemo.Configuration
{
    public class TableAConfiguration : IEntityTypeConfiguration<TableA>
    {
        public void Configure(EntityTypeBuilder<TableA> builder)
        {
            builder.ToTable("TabelleA", "Stammdaten");

            builder.HasKey(p => p.Id).HasName("PK_TabelleA");
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Data).HasColumnName("Daten");
        }
    }
}