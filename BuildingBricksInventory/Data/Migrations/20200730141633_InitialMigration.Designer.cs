﻿// <auto-generated />
using BuildingBricksInventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuildingBricksInventory.Data.Migrations
{
    [DbContext(typeof(BBIContext))]
    [Migration("20200730141633_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BuildingBricksInventory.Data.Brick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bricks");

                    b.HasData(
                        new
                        {
                            Id = 3039,
                            Color = "Red",
                            ImageUrl = "/Brick1.jpg",
                            Name = "Slope Brick 2 x 2, 45 Degrees"
                        },
                        new
                        {
                            Id = 4445,
                            Color = "Red",
                            ImageUrl = "/Brick2.jpg",
                            Name = "Slope Brick 45 2 x 8"
                        },
                        new
                        {
                            Id = 3003,
                            Color = "Yellow",
                            ImageUrl = "/Brick3.jpg",
                            Name = "Brick 2 x 2"
                        },
                        new
                        {
                            Id = 3022,
                            Color = "Black",
                            ImageUrl = "/Brick4.jpg",
                            Name = "Plate 2 x 2"
                        },
                        new
                        {
                            Id = 3010,
                            Color = "Yellow",
                            ImageUrl = "/Brick5.jpg",
                            Name = "Brick 1 x 4"
                        });
                });

            modelBuilder.Entity("BuildingBricksInventory.Data.LegoCollectionBricks", b =>
                {
                    b.Property<int>("BrickId")
                        .HasColumnType("int");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.HasKey("BrickId");

                    b.ToTable("LegoCollectionBricks");

                    b.HasData(
                        new
                        {
                            BrickId = 3003,
                            Amount = 1L
                        },
                        new
                        {
                            BrickId = 4445,
                            Amount = 7L
                        });
                });

            modelBuilder.Entity("BuildingBricksInventory.Data.LegoCollectionSets", b =>
                {
                    b.Property<int>("SetId")
                        .HasColumnType("int");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.HasKey("SetId");

                    b.ToTable("LegoCollectionSets");

                    b.HasData(
                        new
                        {
                            SetId = 6365,
                            Amount = 1L
                        });
                });

            modelBuilder.Entity("BuildingBricksInventory.Data.LegoSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LegoSets");

                    b.HasData(
                        new
                        {
                            Id = 6360,
                            ImageUrl = "/Set6360.jpg",
                            Name = "LEGO 6360 Weekend Cottage"
                        },
                        new
                        {
                            Id = 6365,
                            ImageUrl = "/Set6365.jpg",
                            Name = "LEGO 6365 Summer Cottage"
                        },
                        new
                        {
                            Id = 6349,
                            ImageUrl = "/Set6349.jpg",
                            Name = "Lego 6349 Vacation House"
                        });
                });

            modelBuilder.Entity("BuildingBricksInventory.Data.LegoSetBricks", b =>
                {
                    b.Property<int>("SetId")
                        .HasColumnType("int");

                    b.Property<int>("BrickId")
                        .HasColumnType("int");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.HasKey("SetId", "BrickId");

                    b.HasIndex("BrickId");

                    b.ToTable("LegoSetBricks");

                    b.HasData(
                        new
                        {
                            SetId = 6360,
                            BrickId = 3039,
                            Amount = 6L
                        },
                        new
                        {
                            SetId = 6360,
                            BrickId = 4445,
                            Amount = 7L
                        },
                        new
                        {
                            SetId = 6360,
                            BrickId = 3003,
                            Amount = 5L
                        },
                        new
                        {
                            SetId = 6360,
                            BrickId = 3022,
                            Amount = 1L
                        },
                        new
                        {
                            SetId = 6360,
                            BrickId = 3010,
                            Amount = 2L
                        },
                        new
                        {
                            SetId = 6365,
                            BrickId = 3039,
                            Amount = 8L
                        },
                        new
                        {
                            SetId = 6365,
                            BrickId = 3003,
                            Amount = 2L
                        },
                        new
                        {
                            SetId = 6365,
                            BrickId = 3022,
                            Amount = 1L
                        },
                        new
                        {
                            SetId = 6365,
                            BrickId = 3010,
                            Amount = 7L
                        },
                        new
                        {
                            SetId = 6349,
                            BrickId = 3039,
                            Amount = 4L
                        },
                        new
                        {
                            SetId = 6349,
                            BrickId = 4445,
                            Amount = 4L
                        },
                        new
                        {
                            SetId = 6349,
                            BrickId = 3003,
                            Amount = 3L
                        });
                });

            modelBuilder.Entity("BuildingBricksInventory.Data.LegoCollectionBricks", b =>
                {
                    b.HasOne("BuildingBricksInventory.Data.Brick", "Brick")
                        .WithMany()
                        .HasForeignKey("BrickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuildingBricksInventory.Data.LegoCollectionSets", b =>
                {
                    b.HasOne("BuildingBricksInventory.Data.LegoSet", "Set")
                        .WithMany()
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuildingBricksInventory.Data.LegoSetBricks", b =>
                {
                    b.HasOne("BuildingBricksInventory.Data.Brick", "Brick")
                        .WithMany()
                        .HasForeignKey("BrickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingBricksInventory.Data.LegoSet", "Set")
                        .WithMany("SetBricks")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}