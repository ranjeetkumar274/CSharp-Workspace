using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<User> Users {get;set;}
        public DbSet<PartyHall> PartyHalls {get;set;}
        public DbSet<Booking> Bookings {get;set;}
        public DbSet<Review> Reviews {get;set;}
        
    }
}