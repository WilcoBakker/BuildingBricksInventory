using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingBricksInventory.Data
{
    public class BBIContext : DbContext
    {
        public DbSet<Brick> Bricks { get; set; }
        public DbSet<LegoSet> LegoSets { get; set; }
        public DbSet<LegoSetBricks> LegoSetBricks { get; set; }
        public DbSet<LegoCollectionBricks> LegoCollectionBricks { get; set; }
        public DbSet<LegoCollectionSets> LegoCollectionSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brick>(e =>
            {
                e.HasData(new Brick[]
                {
                    new Brick
                    {
                        Id = 3039,
                        Name = "Slope Brick 2 x 2, 45 Degrees",
                        ImageUrl = "/Brick1.jpg",
                        Color = "Red",
                    },
                    new Brick
                    {
                        Id = 4445,
                        Name = "Slope Brick 45 2 x 8",
                        ImageUrl = "/Brick2.jpg",
                        Color = "Red",
                    },
                    new Brick
                    {
                        Id = 3003,
                        Name = "Brick 2 x 2",
                        ImageUrl = "/Brick3.jpg",
                        Color = "Yellow",
                    },
                    new Brick
                    {
                        Id = 3022,
                        Name = "Plate 2 x 2",
                        ImageUrl = "/Brick4.jpg",
                        Color = "Black",
                    },
                    new Brick
                    {
                        Id = 3010,
                        Name = "Brick 1 x 4",
                        ImageUrl = "/Brick5.jpg",
                        Color = "Yellow",
                    },
                });
            });

            modelBuilder.Entity<LegoSet>(e =>
            {
                e.HasData(new LegoSet[]
                {
                    new LegoSet
                    {
                        Id = 6360,
                        Name = "LEGO 6360 Weekend Cottage",
                        ImageUrl = "/Set6360.jpg",
                    },
                    new LegoSet
                    {
                        Id = 6365,
                        Name = "LEGO 6365 Summer Cottage",
                        ImageUrl = "/Set6365.jpg",
                    },
                    new LegoSet
                    {
                        Id = 6349,
                        Name = "Lego 6349 Vacation House",
                        ImageUrl = "/Set6349.jpg",
                    }
                });
            });

            modelBuilder.Entity<LegoSetBricks>(e =>
            {
                e.HasKey(x => new { x.SetId, x.BrickId });

                e.HasOne(x => x.Set)
                    .WithMany(x => x.SetBricks)
                    .HasForeignKey(x => x.SetId)
                    .IsRequired();

                e.HasOne(x => x.Brick)
                    .WithMany()
                    .HasForeignKey(x => x.BrickId)
                    .IsRequired();

                e.HasData(new LegoSetBricks[]
                {
                    new LegoSetBricks
                    {
                        SetId = 6360,
                        BrickId = 3039,
                        Amount = 6,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6360,
                        BrickId = 4445,
                        Amount = 7,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6360,
                        BrickId = 3003,
                        Amount = 5,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6360,
                        BrickId = 3022,
                        Amount = 1,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6360,
                        BrickId = 3010,
                        Amount = 2,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6365,
                        BrickId = 3039,
                        Amount = 8,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6365,
                        BrickId = 3003,
                        Amount = 2,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6365,
                        BrickId = 3022,
                        Amount = 1,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6365,
                        BrickId = 3010,
                        Amount = 7,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6349,
                        BrickId = 3039,
                        Amount = 4,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6349,
                        BrickId = 4445,
                        Amount = 4,
                    },
                    new LegoSetBricks
                    {
                        SetId = 6349,
                        BrickId = 3003,
                        Amount = 3,
                    },
                });
            });

            modelBuilder.Entity<LegoCollectionBricks>(e =>
            {
                e.HasKey(x => new { x.BrickId });

                e.HasOne(x => x.Brick)
                    .WithMany()
                    .HasForeignKey(x => x.BrickId)
                    .IsRequired();

                e.HasData(new LegoCollectionBricks[]
                {
                    new LegoCollectionBricks
                    {
                        BrickId = 3003,
                        Amount = 1,
                    },
                    new LegoCollectionBricks
                    {
                        BrickId = 4445,
                        Amount = 7,
                    },
                });
            });

            modelBuilder.Entity<LegoCollectionSets>(e =>
            {
                e.HasKey(x => new { x.SetId });

                e.HasOne(x => x.Set)
                    .WithMany()
                    .HasForeignKey(x => x.SetId)
                    .IsRequired();

                e.HasData(new LegoCollectionSets[]
                {
                    new LegoCollectionSets
                    {
                        SetId = 6365,
                        Amount = 1,
                    },
                });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-01AN1HJ\SQLDEV;Initial Catalog=VABI;Integrated Security=True");
        }
    }
}
