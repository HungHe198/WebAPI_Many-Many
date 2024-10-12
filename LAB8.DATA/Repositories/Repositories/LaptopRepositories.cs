using LAB8.DATA.Models;
using LAB8.DATA.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.DATA.Repositories.Repositories
{
    public class LaptopRepositories : IRepositoriesAppAPI<Laptop>
    {
        private readonly AppAPIDbContext _context;

        public LaptopRepositories(AppAPIDbContext context)
        {
            _context = context;
        }

        public async Task<Laptop> Create(Laptop entity)
        {
            try
            {
                _context.Laptops.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }
        }

        public async Task DeleteById(int id)
        {
            try
            {
                var delP = await GetById(id);
                _context.Laptops.Remove(delP);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                e.Message.ToString();

            }
        }

        public async Task<IEnumerable<Laptop>> GetAll()
        {
            return await _context.Laptops.ToListAsync();
        }

        public async Task<Laptop> GetById(int id)
        {
            return await _context.Laptops.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(int id, Laptop entity)
        {
            try
            {
                var updateP = await GetById(id);
                updateP.Name = entity.Name;
                updateP.HangMay = entity.HangMay;
                updateP.NgaySanXuat = entity.NgaySanXuat;
                updateP.MaLaptop = entity.MaLaptop;
                updateP.Desception = entity.Desception;
                

                _context.Laptops.Remove(updateP);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                e.Message.ToString();

            }
        }
    }
}
