using System.Collections.Generic;
using System.Threading.Tasks;
using Schronisko.Entities;
using Schronisko.Models;

namespace Schronisko.Service
{
    public interface IDogService
    {
        Task<Dog> GetById(int id);
        Task Create(DogModel dogModel);
        Task Remove(int id);
        Task Update(DogModel dogModel);
        Task<IEnumerable<Dog>> GetAll();
    }
}