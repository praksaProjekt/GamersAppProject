﻿using Microsoft.EntityFrameworkCore;

namespace GamersApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        public DbSet<UserGame> UserGames { get; set; }

    }
}
