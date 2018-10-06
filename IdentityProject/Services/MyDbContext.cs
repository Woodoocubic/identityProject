using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Models;


namespace IdentityProject.Services
{
    public class MyDbContext:IdentityDbContext  
    {
        public DbSet<Profile> TblProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=IPDDatabase ;Trusted_Connection=True");
        }
    }
}
