using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestao_Patrimonial.Data;
using Gestao_Patrimonial.Models;
using Gestao_Patrimonial.Services.Exceptions;
using Microsoft.EntityFrameworkCore; // Necessário para fazer o join de tabelas

namespace Gestao_Patrimonial.Services
{
    public class SellerService
    {
        private readonly Gestao_PatrimonialContext _context;
        public SellerService(Gestao_PatrimonialContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() // era assim: public List<Seller> FindAll()
        {
            return await _context.Seller.Include(obj => obj.Department).Where(obj => obj.DepartmentId == obj.Department.Id).ToListAsync();
        }

        public async Task InsertAsync(Seller obj) // era assim: public void Insert(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync(); // era assim: _context.SaveChanges();
        }

        public async Task<Seller> FindByIdAsync(int id) // era assim: public Seller FindById(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("It's not possible to delete this seller because he has sales");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }

}
