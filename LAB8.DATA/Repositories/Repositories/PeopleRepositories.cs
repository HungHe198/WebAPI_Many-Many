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
    public class PeopleRepositories : IRepositoriesAppAPI<People>
    {
        private readonly AppAPIDbContext _context;

        public PeopleRepositories(AppAPIDbContext context)
        {
            _context = context;
        }

        public async Task<People> Create(People entity)
        {
            try
            {
                _context.Peoples.Add(entity);
                //if (entity.IdCar != null)
                //{
                //    foreach (var item in entity.IdCar)
                //    {
                //        Car_People newCP = new Car_People() { CarId = item, PeopleId = entity.ID };
                //        _context.Car_Peoples.Add(newCP);
                //    }
                //}
                //if (entity.IdLaptop != null)
                //{
                //    foreach (var item in entity.IdLaptop)
                //    {
                //        Laptop_People newLP = new Laptop_People() { LaptopId = item, PeopleId = entity.ID };
                //        _context.Laptop_Peoples.Add(newLP);
                //    }
                //}


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
                _context.Peoples.Remove(delP);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                e.Message.ToString();

            }
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            return await _context.Peoples.ToListAsync();
        }

        public async Task<People> GetById(int id)
        {
            return await _context.Peoples.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task Update(int id, People entity)
        {
            try
            {
                var updateP = await GetById(id);
                updateP.Name = entity.Name;
                updateP.Age = entity.Age;
                updateP.Phone = entity.Phone;
                updateP.MoTa = entity.MoTa;
                updateP.IdCar = entity.IdCar;
                updateP.IdLaptop = entity.IdLaptop;

                _context.Peoples.Update(updateP);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                e.Message.ToString();

            }
        }
    }
}
