using System;
using Escola.Domain.Entidades;
using Escola.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Mapeamentos
{
    public class EscolaridadeMapeamento : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.ToTable("Escolaridade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EscolaridadeTipo).HasConversion<string>().HasColumnType("varchar(50)").IsRequired();

            builder.HasData(
                new
                {
                    Id = new Guid("5ed433bb-5687-4b00-9d1b-84717101ac48"),
                    EscolaridadeTipo = EscolaridadeEnum.Infantil
                },
                new
                {
                    Id = new Guid("ce280415-4d18-4637-9244-7b76b69274a4"),
                    EscolaridadeTipo = EscolaridadeEnum.Fundamental
                },
                new
                {
                    Id = new Guid("ef4565e5-b230-4182-89f1-0ebfc1e26563"),
                    EscolaridadeTipo = EscolaridadeEnum.Medio
                },
                new
                {
                    Id = new Guid("3165c861851b49138ced539bcb35af63"),
                    EscolaridadeTipo = EscolaridadeEnum.Superior
                }
            );
        }
    }
}
