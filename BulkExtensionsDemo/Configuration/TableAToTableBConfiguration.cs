using BulkExtensionsDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkExtensionsDemo.Configuration
{
    public class TableAToTableBConfiguration : IEntityTypeConfiguration<TableAToTableB>
    {
        public void Configure(EntityTypeBuilder<TableAToTableB> builder)
        {
            builder.ToTable("TabelleAZuTabelleB", "Stammdaten");

            builder.HasKey(p => p.Id).HasName("PK_TabelleAZuTabelleB");
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder
                .Property(s => s.TableAId)
                .HasColumnName("TabelleAId");

            builder
                .Property(s => s.TableBId)
                .HasColumnName("TabelleBId");

            builder.HasIndex(e => new {e.TableAId, e.TableBId}).HasDatabaseName("IX_TabelleA_TabelleB");

            builder.HasOne(d => d.TableA)
                .WithMany(p => p.Relations)
                .HasForeignKey(d => d.TableAId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TabelleA");

            builder.HasOne(d => d.TableB)
                .WithMany(p => p.Relations)
                .HasForeignKey(d => d.TableBId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TabelleB");
        }
    }
}