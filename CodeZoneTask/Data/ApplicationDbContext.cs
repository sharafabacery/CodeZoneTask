﻿using Microsoft.EntityFrameworkCore;
using CodeZoneTask.DTO;

namespace CodeZoneTask.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
        public DbSet<CodeZoneTask.DTO.StockDTO> StockDTO { get; set; } = default!;

    }
}
