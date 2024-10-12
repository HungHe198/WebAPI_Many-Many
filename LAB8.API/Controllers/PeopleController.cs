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
    public class PeopleController : ControllerBase
    {
        private readonly IRepositoriesAppAPI<People> _repo;

        public PeopleController(IRepositoriesAppAPI<People> repo)
        {
            _repo = repo;
        }



        // GET: api/People
        [HttpGet]
        public async Task<IEnumerable<People>> GetPeoples()
        {
            return await _repo.GetAll();
           
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<People> GetPeople(int id)
        {
            return await _repo.GetById(id);
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutPeople(int id, People people)
        {

            await _repo.Update(id, people);
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<People> PostPeople(People people)
        {
            return await _repo.Create(people);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task DeletePeople(int id)
        {
           await _repo.DeleteById(id);
        }

    }
}
