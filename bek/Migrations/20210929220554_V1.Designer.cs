﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bek.Models;

namespace bek.Migrations
{
    [DbContext(typeof(SalaContext))]
    [Migration("20210929220554_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bek.Models.Osoba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojKarte")
                        .HasColumnType("int")
                        .HasColumnName("BrojKarte");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prezime");

                    b.Property<int?>("SedisteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SedisteID");

                    b.ToTable("Osoba");
                });

            modelBuilder.Entity("bek.Models.Sala", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojMestaPoRedu")
                        .HasColumnType("int")
                        .HasColumnName("BrojMestaPoRedu");

                    b.Property<int>("BrojRedova")
                        .HasColumnType("int")
                        .HasColumnName("BrojRedova");

                    b.Property<int>("BrojSale")
                        .HasColumnType("int")
                        .HasColumnName("BrojSale");

                    b.HasKey("ID");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("bek.Models.Sediste", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SalaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SalaID");

                    b.ToTable("Sediste");
                });

            modelBuilder.Entity("bek.Models.Osoba", b =>
                {
                    b.HasOne("bek.Models.Sediste", "Sediste")
                        .WithMany("Osobe")
                        .HasForeignKey("SedisteID");

                    b.Navigation("Sediste");
                });

            modelBuilder.Entity("bek.Models.Sediste", b =>
                {
                    b.HasOne("bek.Models.Sala", "Sala")
                        .WithMany("Sedista")
                        .HasForeignKey("SalaID");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("bek.Models.Sala", b =>
                {
                    b.Navigation("Sedista");
                });

            modelBuilder.Entity("bek.Models.Sediste", b =>
                {
                    b.Navigation("Osobe");
                });
#pragma warning restore 612, 618
        }
    }
}