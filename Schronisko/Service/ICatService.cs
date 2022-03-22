using System.Collections.Generic;
using System.Threading.Tasks;
using Schronisko.Entities;
using Schronisko.Models;

namespace Schronisko.Service
{
    public interface ICatService
    {
        Task<Cat> GetById(int id);
        Task Create(CatModel catModel);
        Task Remove(int id);
        Task Update(CatModel catModel);
        Task<IEnumerable<Cat>> GetAll();
    }
}