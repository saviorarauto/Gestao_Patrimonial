using Gestao_Patrimonial.Data;
using Gestao_Patrimonial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Patrimonial.Services
{
    public class DepartmentService
    {
        private readonly Gestao_PatrimonialContext _context;
        public DepartmentService(Gestao_PatrimonialContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync() // Antes era assim: public List<Department> FindAll()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); // era assim: return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
