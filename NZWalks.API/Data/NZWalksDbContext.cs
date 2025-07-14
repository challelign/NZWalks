using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 👉 Configure relationships explicitly
            modelBuilder.Entity<Walk>()
                .HasOne(w => w.Region)
                .WithMany()
                .HasForeignKey(w => w.RegionId);

            modelBuilder.Entity<Walk>()
                .HasOne(w => w.Difficulty)
                .WithMany()
                .HasForeignKey(w => w.DifficultyId);

            // 👉 Seed Difficulties
            var diff = new List<Difficulty>
            {
                new Difficulty { Id = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("2753b649-7f84-41d5-9002-aa5caec518c3"), Name = "Medium" },
                new Difficulty { Id = Guid.Parse("27e7b6b0-11c4-4b57-a152-ed9deea60be1"), Name = "Hard" }
            };
            modelBuilder.Entity<Difficulty>().HasData(diff);

            // 👉 Seed Regions
            var region = new List<Region>
            {
                new Region { Id = Guid.Parse("a1f70de2-9c49-4cf1-9d2b-3eaa2bc11111"), Code = "AKL", Name = "Auckland", RegionImageUrl = "https://example.com/images/auckland.jpg" },
                new Region { Id = Guid.Parse("b2f70de2-9c49-4cf1-9d2b-3eaa2bc12222"), Code = "WGN", Name = "Wellington", RegionImageUrl = "https://example.com/images/wellington.jpg" },
                new Region { Id = Guid.Parse("c3f70de2-9c49-4cf1-9d2b-3eaa2bc13333"), Code = "CHC", Name = "Christchurch", RegionImageUrl = "https://example.com/images/christchurch.jpg" },
                new Region { Id = Guid.Parse("d4f70de2-9c49-4cf1-9d2b-3eaa2bc14444"), Code = "DUD", Name = "Dunedin", RegionImageUrl = "https://example.com/images/dunedin.jpg" },
                new Region { Id = Guid.Parse("e5f70de2-9c49-4cf1-9d2b-3eaa2bc15555"), Code = "ROT", Name = "Rotorua", RegionImageUrl = "https://example.com/images/rotorua.jpg" },
                new Region { Id = Guid.Parse("d57f1a68-3a3b-4d4c-bfe8-1b1e7b0c8c8d"), Code = "AEL", Name = "Auckland", RegionImageUrl = "https://example.com/images/auckland.jpg" },
                new Region { Id = Guid.Parse("f5e6b1c4-f8e7-4d7b-bd6e-8d3bcf7d3e7e"), Code = "WLG", Name = "Wellington", RegionImageUrl = "https://example.com/images/wellington.jpg" },
                new Region { Id = Guid.Parse("a6e66c53-bd5e-4c1f-a0f0-6c7f3f1b2c8a"), Code = "CCC", Name = "Christchurch", RegionImageUrl = "https://example.com/images/christchurch.jpg" },
                new Region { Id = Guid.Parse("b8c7f8e2-9c29-4e3a-b0d1-5c8d7e3f8c9e"), Code = "DAE", Name = "Dunedin", RegionImageUrl = "https://example.com/images/dunedin.jpg" },
                new Region { Id = Guid.Parse("c9d3c5b1-9f5c-4f3c-8f4a-5e9a2f3b3f1e"), Code = "NPL", Name = "Napier", RegionImageUrl = "https://example.com/images/napier.jpg" }

            };
            modelBuilder.Entity<Region>().HasData(region);

            // 👉 Seed Walks
            var walk = new List<Walk>
            {
                new Walk {
                    Id = Guid.Parse("f1f70de2-9c49-4cf1-9d2b-3eaa2bc16661"),
                    Name = "Coastal Track",
                    Descripton = "Beautiful track along the coast.",
                    LengthInKm = 5.2,
                    WalkImageUrl = "https://example.com/walks/coastal.jpg",
                    DifficultyId = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"),
                    RegionId = Guid.Parse("a1f70de2-9c49-4cf1-9d2b-3eaa2bc11111")
                },
                new Walk {
                    Id = Guid.Parse("f2f70de2-9c49-4cf1-9d2b-3eaa2bc16662"),
                    Name = "Mountain Hike",
                    Descripton = "Challenging hike up the mountain.",
                    LengthInKm = 12.7,
                    WalkImageUrl = "https://example.com/walks/mountain.jpg",
                    DifficultyId = Guid.Parse("27e7b6b0-11c4-4b57-a152-ed9deea60be1"),
                    RegionId = Guid.Parse("c3f70de2-9c49-4cf1-9d2b-3eaa2bc13333")
                },
                new Walk {
                    Id = Guid.Parse("f3f70de2-9c49-4cf1-9d2b-3eaa2bc16663"),
                    Name = "Forest Trail",
                    Descripton = "Shady forest walk for all skill levels.",
                    LengthInKm = 3.1,
                    WalkImageUrl = "https://example.com/walks/forest.jpg",
                    DifficultyId = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"),
                    RegionId = Guid.Parse("b2f70de2-9c49-4cf1-9d2b-3eaa2bc12222")
                },
                new Walk {
                    Id = Guid.Parse("f4f70de2-9c49-4cf1-9d2b-3eaa2bc16664"),
                    Name = "Lake Loop",
                    Descripton = "Relaxing walk around the lake.",
                    LengthInKm = 4.0,
                    WalkImageUrl = "https://example.com/walks/lake.jpg",
                    DifficultyId = Guid.Parse("2753b649-7f84-41d5-9002-aa5caec518c3"),
                    RegionId = Guid.Parse("e5f70de2-9c49-4cf1-9d2b-3eaa2bc15555")
                },
                new Walk {
                    Id = Guid.Parse("f5f70de2-9c49-4cf1-9d2b-3eaa2bc16665"),
                    Name = "Hill Climb",
                    Descripton = "Medium difficulty hike with great views.",
                    LengthInKm = 6.8,
                    WalkImageUrl = "https://example.com/walks/hill.jpg",
                    DifficultyId = Guid.Parse("2753b649-7f84-41d5-9002-aa5caec518c3"),
                    RegionId = Guid.Parse("d4f70de2-9c49-4cf1-9d2b-3eaa2bc14444")
                },
                new Walk {
                    Id = Guid.Parse("f6f70de2-9c49-4cf1-9d2b-3eaa2bc16666"),
                    Name = "River Walk",
                    Descripton = "Scenic walk along the riverbank.",
                    LengthInKm = 4.5,
                    WalkImageUrl = "https://example.com/walks/river.jpg",
                    DifficultyId = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"),
                    RegionId = Guid.Parse("b2f70de2-9c49-4cf1-9d2b-3eaa2bc12222")
                },
                new Walk {
                    Id = Guid.Parse("f7f70de2-9c49-4cf1-9d2b-3eaa2bc16667"),
                    Name = "Desert Trail",
                    Descripton = "A challenging walk through a desert landscape.",
                    LengthInKm = 10.0,
                    WalkImageUrl = "https://example.com/walks/desert.jpg",
                    DifficultyId = Guid.Parse("27e7b6b0-11c4-4b57-a152-ed9deea60be1"),
                    RegionId = Guid.Parse("d4f70de2-9c49-4cf1-9d2b-3eaa2bc14444")
                },
                new Walk {
                    Id = Guid.Parse("f8f70de2-9c49-4cf1-9d2b-3eaa2bc16668"),
                    Name = "Urban Walk",
                    Descripton = "Explore the city on this urban trail.",
                    LengthInKm = 5.0,
                    WalkImageUrl = "https://example.com/walks/urban.jpg",
                    DifficultyId = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"),
                    RegionId = Guid.Parse("a1f70de2-9c49-4cf1-9d2b-3eaa2bc11111")
                },
                new Walk {
                    Id = Guid.Parse("f9f70de2-9c49-4cf1-9d2b-3eaa2bc16669"),
                    Name = "Wildflower Path",
                    Descripton = "A beautiful trail lined with wildflowers.",
                    LengthInKm = 3.6,
                    WalkImageUrl = "https://example.com/walks/wildflower.jpg",
                    DifficultyId = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"),
                    RegionId = Guid.Parse("c3f70de2-9c49-4cf1-9d2b-3eaa2bc13333")
                },
                new Walk {
                    Id = Guid.Parse("fae70de2-9c49-4cf1-9d2b-3eaa2bc16670"),
                    Name = "Canyon View",
                    Descripton = "Stunning views of the canyon.",
                    LengthInKm = 7.5,
                    WalkImageUrl = "https://example.com/walks/canyon.jpg",
                    DifficultyId = Guid.Parse("27e7b6b0-11c4-4b57-a152-ed9deea60be1"),
                    RegionId = Guid.Parse("d4f70de2-9c49-4cf1-9d2b-3eaa2bc14444")
                },
                new Walk {
                    Id = Guid.Parse("fbf70de2-9c49-4cf1-9d2b-3eaa2bc16671"),
                    Name = "Sunset Trail",
                    Descripton = "A picturesque walk, perfect for sunsets.",
                    LengthInKm = 4.8,
                    WalkImageUrl = "https://example.com/walks/sunset.jpg",
                    DifficultyId = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"),
                    RegionId = Guid.Parse("b2f70de2-9c49-4cf1-9d2b-3eaa2bc12222")
                },
                new Walk {
                    Id = Guid.Parse("fcf70de2-9c49-4cf1-9d2b-3eaa2bc16672"),
                    Name = "Historical Route",
                    Descripton = "Walk through history on this guided trail.",
                    LengthInKm = 6.0,
                    WalkImageUrl = "https://example.com/walks/historical.jpg",
                    DifficultyId = Guid.Parse("2753b649-7f84-41d5-9002-aa5caec518c3"),
                    RegionId = Guid.Parse("a1f70de2-9c49-4cf1-9d2b-3eaa2bc11111")
                },
                new Walk {
                    Id = Guid.Parse("fde70de2-9c49-4cf1-9d2b-3eaa2bc16673"),
                    Name = "Cliffside Walk",
                    Descripton = "An exhilarating walk along the cliffs.",
                    LengthInKm = 8.3,
                    WalkImageUrl = "https://example.com/walks/cliffside.jpg",
                    DifficultyId = Guid.Parse("27e7b6b0-11c4-4b57-a152-ed9deea60be1"),
                    RegionId = Guid.Parse("c3f70de2-9c49-4cf1-9d2b-3eaa2bc13333")
                },
                new Walk {
                    Id = Guid.Parse("fee70de2-9c49-4cf1-9d2b-3eaa2bc16674"),
                    Name = "Beach Walk",
                    Descripton = "A relaxing walk along the beach.",
                    LengthInKm = 2.5,
                    WalkImageUrl = "https://example.com/walks/beach.jpg",
                    DifficultyId = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"),
                    RegionId = Guid.Parse("e5f70de2-9c49-4cf1-9d2b-3eaa2bc15555")
                },
                new Walk {
                    Id = Guid.Parse("fff70de2-9c49-4cf1-9d2b-3eaa2bc16675"),
                    Name = "Snowy Peak Hike",
                    Descripton = "A trek to the snowy peaks.",
                    LengthInKm = 15.0,
                    WalkImageUrl = "https://example.com/walks/snowypeak.jpg",
                    DifficultyId = Guid.Parse("27e7b6b0-11c4-4b57-a152-ed9deea60be1"),
                    RegionId = Guid.Parse("f5e6b1c4-f8e7-4d7b-bd6e-8d3bcf7d3e7e")
                },
                new Walk {
                    Id = Guid.Parse("f0f70de2-9c49-4cf1-9d2b-3eaa2bc16676"),
                    Name = "Treetop Walk",
                    Descripton = "A unique walk among the treetops.",
                    LengthInKm = 3.4,
                    WalkImageUrl = "https://example.com/walks/treetop.jpg",
                    DifficultyId = Guid.Parse("2753b649-7f84-41d5-9002-aa5caec518c3"),
                    RegionId = Guid.Parse("a6e66c53-bd5e-4c1f-a0f0-6c7f3f1b2c8a")
                },
                new Walk {
                    Id = Guid.Parse("f1f70de2-9c49-4cf1-9d2b-3eaa2bc16677"),
                    Name = "Botanical Garden Trail",
                    Descripton = "A serene walk through the botanical gardens.",
                    LengthInKm = 2.2,
                    WalkImageUrl = "https://example.com/walks/botanical.jpg",
                    DifficultyId = Guid.Parse("3caf2feb-8230-4e81-a8ae-202af8e1a93d"),
                    RegionId = Guid.Parse("b8c7f8e2-9c29-4e3a-b0d1-5c8d7e3f8c9e")
                }
            };
            modelBuilder.Entity<Walk>().HasData(walk);
        }
    }
}
