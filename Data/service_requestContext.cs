using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using service_request.Models;

namespace service_request.Data
{
    public class service_requestContext : DbContext
    {
        public service_requestContext (DbContextOptions<service_requestContext> options)
            : base(options)
        {
        }

        public DbSet<service_request.Models.ServiceRequest> ServiceRequest { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceRequest>()
                .Property(s => s.CurrentStatus)
                .HasConversion<string>(); // Store as string instead of integer
        }
    }
}
