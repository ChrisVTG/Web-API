﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Persistence;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(PcrContext))]
    partial class PcrContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("WebApplication1.Entities.PcrTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("AnalysisDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("AnalysisResult")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<int?>("PerformerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ReceptionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SampleNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SamplingDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PerformerId");

                    b.ToTable("PcrTests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnalysisDate = new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AnalysisResult = "Positive",
                            Comment = "this is my comment 1",
                            CreationDate = new DateTime(2023, 10, 30, 12, 54, 30, 0, DateTimeKind.Unspecified),
                            PerformerId = 1,
                            ReceptionDate = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SampleNumber = "ABCD1234",
                            SamplingDate = new DateTime(2023, 10, 30, 12, 54, 30, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AnalysisDate = new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AnalysisResult = "Negative",
                            Comment = "this is my comment 2",
                            CreationDate = new DateTime(2023, 11, 21, 9, 31, 24, 0, DateTimeKind.Unspecified),
                            PerformerId = 2,
                            ReceptionDate = new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SampleNumber = "ZREZ5241",
                            SamplingDate = new DateTime(2023, 11, 21, 9, 31, 24, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WebApplication1.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ludwig",
                            LastName = "Lebrun"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Ludwig",
                            LastName = "Leblanc"
                        });
                });

            modelBuilder.Entity("WebApplication1.Entities.PcrTest", b =>
                {
                    b.HasOne("WebApplication1.Entities.User", "Performer")
                        .WithMany()
                        .HasForeignKey("PerformerId");

                    b.Navigation("Performer");
                });
#pragma warning restore 612, 618
        }
    }
}
