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
    public class Laptop_PeopleController : ControllerBase
    {
        private readonly IRepositoriesJoinTable<Laptop_People> _repo;

        public Laptop_PeopleController(IRepositoriesJoinTable<Laptop_People> repo)
        {
            _repo = repo;
        }

        // GET: api/Laptop_People
        [HttpGet]
        public async Task<IEnumerable<Laptop_People>> GetLaptop_Peoples()
        {
            return await _repo.GetAll();
        }

        // GET: api/Laptop_People/5
        [HttpGet("{id1}/{id2}")]
        public async Task<Laptop_People> GetLaptop_People(int id1, int id2)
        {
           return await GetLaptop_People(id1, id2);
          
        }

        // PUT: api/Laptop_People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id1}/{id2}")] // Laptop / nguoi dung
        public async Task PutLaptop_People(int id1, int id2, Laptop_People laptop_People)
        {
            await _repo.Update(id1, id2, laptop_People);
        }

        // POST: api/Laptop_People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Laptop_People> PostLaptop_People(Laptop_People laptop_People)
        {
          return await _repo.Create(laptop_People);
        }

        // DELETE: api/Laptop_People/5
        [HttpDelete("{id1}/{id2}")]
        public async Task DeleteLaptop_People(int id1, int id2)
        {
            await _repo.DeleteById(id1, id2);
        }

        
    }
}
