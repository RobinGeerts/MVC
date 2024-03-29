﻿// <auto-generated />
using System;
using HondenRescue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HondenRescue.Migrations
{
    [DbContext(typeof(HRContext))]
    partial class HRContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HondenRescue.Models.Eigenaar", b =>
                {
                    b.Property<int>("EigenaarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EigenaarId"), 1L, 1);

                    b.Property<string>("Familienaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EigenaarId");

                    b.ToTable("Eigenaar", (string)null);
                });

            modelBuilder.Entity("HondenRescue.Models.Hond", b =>
                {
                    b.Property<int>("HondId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HondId"), 1L, 1);

                    b.Property<int>("EigenaarId")
                        .HasColumnType("int");

                    b.Property<string>("FotoNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Geboortedatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Gechipt")
                        .HasColumnType("bit");

                    b.Property<int>("Geslacht")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LaatsteVaccinatieDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opmerkingen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HondId");

                    b.HasIndex("EigenaarId");

                    b.ToTable("Hond", (string)null);
                });

            modelBuilder.Entity("HondenRescue.Models.Hond", b =>
                {
                    b.HasOne("HondenRescue.Models.Eigenaar", "Eigenaar")
                        .WithMany("Honden")
                        .HasForeignKey("EigenaarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eigenaar");
                });

            modelBuilder.Entity("HondenRescue.Models.Eigenaar", b =>
                {
                    b.Navigation("Honden");
                });
#pragma warning restore 612, 618
        }
    }
}
