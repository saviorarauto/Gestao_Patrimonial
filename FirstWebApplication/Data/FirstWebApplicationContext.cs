using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestao_Patrimonial.Models;

namespace Gestao_Patrimonial.Data
{
    public class Gestao_PatrimonialContext : DbContext
    {
        public Gestao_PatrimonialContext (DbContextOptions<Gestao_PatrimonialContext> options)
            : base(options)
        {
        }

        public DbSet<Gestao_Patrimonial.Models.Department> Department { get; set; }
        public DbSet<Gestao_Patrimonial.Models.Seller> Seller { get; set; }
        public DbSet<Gestao_Patrimonial.Models.SalesRecord> SalesRecord { get; set; }
    }
}
