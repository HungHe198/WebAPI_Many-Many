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
    public class Laptop_People_Repositories : IRepositoriesJoinTable<Laptop_People>
    {
        private readonly AppAPIDbContext _context;

        public Laptop_People_Repositories(AppAPIDbContext context)
        {
            _context = context;
        }

        public async Task<Laptop_People> Create(Laptop_People entity)
        {
            try
            {
                _context.Laptop_Peoples.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public async Task DeleteById(int id1, int id2)
        {
            try
            {
                var DelLP = await GetById(id1, id2);
                _context.Laptop_Peoples.Remove(DelLP);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            { e.Message.ToString(); }
        }

        public async Task<IEnumerable<Laptop_People>> GetAll()
        {
           return await _context.Laptop_Peoples.ToListAsync();
        }

        public async Task<Laptop_People> GetById(int id1, int id2)
        {
            return await _context.Laptop_Peoples.FirstOrDefaultAsync(lp => lp.LaptopId == id1 && lp.PeopleId == id2);
        }

        public async Task Update(int id1, int id2, Laptop_People entity)
        {
            try
            {
                var updateLP = await GetById(id1, id2);
                updateLP.LaptopId = entity.LaptopId;
                updateLP.PeopleId = entity.PeopleId;
                _context.Laptop_Peoples.Update(updateLP);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) { e.Message.ToString(); }
        }

     


    }
}
