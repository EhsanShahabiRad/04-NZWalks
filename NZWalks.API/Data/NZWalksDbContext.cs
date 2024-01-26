using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base (dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


       

    }


    
}
