﻿// <auto-generated />
using Jogadores_Time.Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jogadores_Time.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210720183256_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jogadores_Time.Shared.Models.Jogadores", b =>
                {
                    b.Property<int>("JogadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Naturalidade")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Posicao")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.HasKey("JogadorId");

                    b.HasIndex("TimeId");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("Jogadores_Time.Shared.Models.Time", b =>
                {
                    b.Property<int>("TimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("ImagemURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("QuantidadeDeTitulos")
                        .HasColumnType("int");

                    b.HasKey("TimeId");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("Jogadores_Time.Shared.Models.Jogadores", b =>
                {
                    b.HasOne("Jogadores_Time.Shared.Models.Time", "Time")
                        .WithMany("Jogadores")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}