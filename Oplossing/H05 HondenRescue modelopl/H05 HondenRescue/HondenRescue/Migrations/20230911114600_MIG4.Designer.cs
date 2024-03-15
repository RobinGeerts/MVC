﻿// <auto-generated />
using System;
using HondenRescue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HondenRescue.Migrations
{
    [DbContext(typeof(HRContext))]
    [Migration("20230911114600_MIG4")]
    partial class MIG4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HondenRescue.Models.Hond", b =>
                {
                    b.Property<int>("HondId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HondId"), 1L, 1);

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

                    b.ToTable("Hond", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
