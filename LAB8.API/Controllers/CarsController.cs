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
    public class CarsController : ControllerBase
    {
        private readonly IRepositoriesAppAPI<Car> _repo;

        public CarsController(IRepositoriesAppAPI<Car> repo)
        {
            _repo = repo;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _repo.GetAll();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<Car> GetCar(int id)
        {
            return await _repo.GetById(id);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutCar(int id, Car car)
        {
            await _repo.Update(id, car);
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Car> PostCar(Car car)
        {
            return await _repo.Create(car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task DeleteCar(int id)
        {
            await _repo.DeleteById(id);

        }

    }
}
