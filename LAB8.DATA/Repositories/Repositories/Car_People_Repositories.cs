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
    public class Car_People_Repositories : IRepositoriesJoinTable<Car_People>
    {
        private readonly AppAPIDbContext _context;

        public Car_People_Repositories(AppAPIDbContext context)
        {
            _context = context;
        }

        public async Task<Car_People> Create(Car_People entity)
        {
            try
            {
                _context.Car_Peoples.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }
        }

        public async Task DeleteById(int id1, int id2)
        {
            try
            {
                var DelCP = await GetById(id1, id2);
                _context.Car_Peoples.Remove(DelCP);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            { e.Message.ToString(); }
        }

        public async Task<IEnumerable<Car_People>> GetAll()
        {
            return await _context.Car_Peoples.ToListAsync();
        }

        public async Task<Car_People> GetById(int id1, int id2)
        {
            return await _context.Car_Peoples.FirstOrDefaultAsync(cp => cp.CarId == id1 && cp.PeopleId == id2);
        }

        public async Task Update(int id1, int id2, Car_People entity)
        {
            try
            {
                var updateCP = await GetById(id1, id2);
                updateCP.CarId = entity.CarId;
                updateCP.PeopleId = entity.PeopleId;
                _context.Car_Peoples.Update(updateCP);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) { e.Message.ToString(); }
        }
    }
}
