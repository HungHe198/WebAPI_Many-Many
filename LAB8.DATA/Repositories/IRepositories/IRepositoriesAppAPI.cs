using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.DATA.Repositories.IRepositories
{
    public interface IRepositoriesAppAPI<H> where H : class
    {
        Task<IEnumerable<H>> GetAll();
        Task<H> GetById(int id);
        Task<H> Create(H entity);
        Task Update(int id, H entity);
        Task DeleteById(int id);

    }
}
