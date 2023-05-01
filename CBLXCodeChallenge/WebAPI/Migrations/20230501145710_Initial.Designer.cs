﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20230501145710_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Models.Cargueiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CapacidadeEmToneladas")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Capacidade");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Classe");

                    b.Property<int>("MineralId")
                        .HasColumnType("int")
                        .HasColumnName("Tipo_Mineral");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("MineralId");

                    b.ToTable("Cargueiros");
                });

            modelBuilder.Entity("WebAPI.Models.Mineral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Caracteristica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Caracteristica");

                    b.Property<decimal>("PrecoPorKg")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Preco");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Minerais");
                });

            modelBuilder.Entity("WebAPI.Models.Cargueiro", b =>
                {
                    b.HasOne("WebAPI.Models.Mineral", "Mineral")
                        .WithMany()
                        .HasForeignKey("MineralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mineral");
                });
#pragma warning restore 612, 618
        }
    }
}