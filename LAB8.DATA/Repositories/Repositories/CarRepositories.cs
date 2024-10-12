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
    public class CarRepositories : IRepositoriesAppAPI<Car>
    {
        private readonly AppAPIDbContext _context;

        public CarRepositories(AppAPIDbContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(Car entity)
        {
            try { 
                _context.Cars.Add(entity);
                await _context.SaveChangesAsync();  
                return entity;
            }
            catch (Exception ex) {
                ex.Message.ToString();
                return null;
            }
        }

        public async Task DeleteById(int id)
        {
            try {
                var delC = await GetById(id);
                _context.Cars.Remove(delC);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }

        public Task<Car> GetById(int id)
        {
            return _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(int id, Car entity)
        {
            try {
                var updateC = await GetById(id);
                updateC.Name = entity.Name;
                updateC.HangXe = entity.HangXe;
                updateC.NgaySanXuat = entity.NgaySanXuat;
                updateC.Desception = entity.Desception;

                _context.Cars.Update(updateC);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
