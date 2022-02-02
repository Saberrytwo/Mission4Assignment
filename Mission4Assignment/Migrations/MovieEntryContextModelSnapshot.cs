﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission4Assignment.Models;

namespace Mission4Assignment.Migrations
{
    [DbContext(typeof(MovieEntryContext))]
    partial class MovieEntryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("Mission4Assignment.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Animated"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Space"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Pensive"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Who Knows?"
                        });
                });

            modelBuilder.Entity("Mission4Assignment.Models.MovieEntry", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CategoryId = 1,
                            Director = "IDK",
                            Edited = false,
                            LentTo = "Nah",
                            Notes = "Favorite Movie Ever",
                            Rating = "PG",
                            Title = "How to Train Your Dragon",
                            Year = 2010
                        },
                        new
                        {
                            MovieId = 2,
                            CategoryId = 2,
                            Director = "Christopher Nolan",
                            Edited = false,
                            LentTo = "Nah",
                            Notes = "Top 5",
                            Rating = "PG-13",
                            Title = "Interstellar",
                            Year = 2014
                        },
                        new
                        {
                            MovieId = 3,
                            CategoryId = 3,
                            Director = "Kenneth Logernan",
                            Edited = false,
                            LentTo = "Nah",
                            Notes = "Promising",
                            Rating = "R",
                            Title = "Manchester by the Sea",
                            Year = 2016
                        });
                });

            modelBuilder.Entity("Mission4Assignment.Models.MovieEntry", b =>
                {
                    b.HasOne("Mission4Assignment.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
