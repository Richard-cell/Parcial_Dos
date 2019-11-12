﻿// <auto-generated />
using System;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Migrations
{
    [DbContext(typeof(EntidadContext))]
    partial class EntidadContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entidades.Credito", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cedula")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlazoPago")
                        .HasColumnType("int");

                    b.Property<float>("ValorPrestamo")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Credito");
                });

            modelBuilder.Entity("Domain.Entidades.Cuota", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreditoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPagoCuota")
                        .HasColumnType("datetime2");

                    b.Property<int>("MesCuota")
                        .HasColumnType("int");

                    b.Property<float>("ValorCuota")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("CreditoId");

                    b.ToTable("Cuota");
                });

            modelBuilder.Entity("Domain.Entidades.Cuota", b =>
                {
                    b.HasOne("Domain.Entidades.Credito", null)
                        .WithMany("Cuotas")
                        .HasForeignKey("CreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}