using FlightScheduleApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightScheduleApi.Data.Mappings
{
    public class AeronaveMapping : IEntityTypeConfiguration<Aeronave>
    {
        public void Configure(EntityTypeBuilder<Aeronave> builder)
        {
            builder.HasKey(p => p.Id); //--- Chave primária

            //--- Cria as propriedades
            builder.Property(p => p.Matricula)
                .IsRequired()
                .HasColumnType("varchar(5)");

            builder.Property(p => p.Fabricante)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Categoria)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Modelo)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.ToTable("Aeronaves");
        }
    }
}
