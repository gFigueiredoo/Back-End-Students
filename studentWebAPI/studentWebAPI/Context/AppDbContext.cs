using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using studentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentWebAPI.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>().HasData(
        //        new Student
        //        {
        //            Id = 1,
        //            Name = "Mariazinha",
        //            Email = "mariasicredi@gmail.com",
        //            Age = 20,
        //        },
        //        new Student
        //        {
        //            Id = 2,
        //            Name = "Angelao",
        //            Email = "angelaoCSGO@gmail.com",
        //            Age = 21,
        //        }
        //    );
        //}
    }
}
