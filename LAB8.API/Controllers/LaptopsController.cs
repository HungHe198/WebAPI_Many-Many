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
    public class LaptopsController : ControllerBase
    {
        private readonly IRepositoriesAppAPI<Laptop> _repo;
        public LaptopsController(IRepositoriesAppAPI<Laptop> repo)
        {
            _repo = repo;
        }

        // GET: api/Laptops
        [HttpGet]
        public async Task<IEnumerable<Laptop>> GetLaptops()
        {
            return await _repo.GetAll();
        }

        // GET: api/Laptops/5
        [HttpGet("{id}")]
        public async Task<Laptop> GetLaptop(int id)
        {
            return  await _repo.GetById(id);
        }

        // PUT: api/Laptops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutLaptop(int id, Laptop laptop)
        {
            await _repo.Update(id, laptop);
        }

        // POST: api/Laptops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Laptop> PostLaptop(Laptop laptop)
        {
            return await _repo.Create(laptop);    
        }

        // DELETE: api/Laptops/5
        [HttpDelete("{id}")]
        public async Task DeleteLaptop(int id)
        {
            await _repo.DeleteById(id);
            
        }
    }
}
