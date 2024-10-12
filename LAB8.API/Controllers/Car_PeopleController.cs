using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LAB8.DATA.Models;
using LAB8.DATA.Repositories.IRepositories;

namespace LAB8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Car_PeopleController : ControllerBase
    {
        private readonly IRepositoriesJoinTable<Car_People> _repo;

        public Car_PeopleController(IRepositoriesJoinTable<Car_People> repo)
        {
            _repo = repo;
        }


        // GET: api/Car_People
        [HttpGet]
        public async Task<IEnumerable<Car_People>> GetCar_Peoples()
        {
          return await  _repo.GetAll();
        }

        // GET: api/Car_People/5
        [HttpGet("{id1}/{id2}")]
        public async Task<Car_People> GetCar_People(int id1,int id2)
        {
            return await _repo.GetById(id1,id2);
        } 

        // PUT: api/Car_People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id1}/{id2}")]
        public async Task PutCar_People(int id1, int id2, Car_People car_People)
        {
            await _repo.Update(id1,id2,car_People);    
           
        }

        // POST: api/Car_People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car_People>> PostCar_People(Car_People car_People)
        {
           return await _repo.Create(car_People);
        }

        // DELETE: api/Car_People/5
        [HttpDelete("{id1}/{id2}")]
        public async Task DeleteCar_People(int id1, int id2)
        {
             await _repo.DeleteById(id1,id2);
        }

     
    }
}
