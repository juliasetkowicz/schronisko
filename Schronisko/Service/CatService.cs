using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schronisko.Database;
using Schronisko.Entities;
using Schronisko.Models;

namespace Schronisko.Service
{
    public class CatService:ICatService
    {
        private readonly AppDbContext _context;

        public CatService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Cat> GetById(int id)
        {
            var cat = await _context.Cats.FirstOrDefaultAsync(c => c.Id == id);
            return cat;
        }

        public async Task Create(CatModel catModel)
        {
            var cat = new Cat()
            {
                Id = catModel.Id,
                Name = catModel.Name, 
                Photo= catModel.Photo,
                Phone= catModel.Phone,
                Age = catModel.Age,
            };
            await _context.Cats.AddAsync(cat);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var cat = await _context.Cats.FirstOrDefaultAsync(c => c.Id == id);
            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CatModel catModel)
        {
            var cat =  await _context.Cats.FirstOrDefaultAsync(c => c.Id == catModel.Id);
            if (cat != null)
            {
                cat.Name = catModel.Name;
                cat.Photo = catModel.Photo;
                cat.Phone = catModel.Phone;
                cat.Age = catModel.Age;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cat>> GetAll()
        {
            var cats =await _context.Cats.ToListAsync();
            return cats;
        }
    }
}