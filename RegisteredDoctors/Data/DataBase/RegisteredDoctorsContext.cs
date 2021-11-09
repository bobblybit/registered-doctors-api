using Microsoft.EntityFrameworkCore;
using RegisteredDoctors.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisteredDoctors.Data
{
    public class RegisteredDoctorsContext : DbContext
    {
        public RegisteredDoctorsContext(DbContextOptions<RegisteredDoctorsContext> options) : base (options)
        {

        }

        public DbSet<RegisteredDoctor> registeredDoctors { get; set; }


    }
}
