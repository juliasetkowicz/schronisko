using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schronisko.Database;
using Schronisko.Entities;
using Schronisko.Models;

namespace Schronisko.Service
{
    public class DogService:IDogService
    {
        private readonly AppDbContext _context;

        public DogService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dog> GetById(int id)
        {
            var dog = await _context.Dogs.FirstOrDefaultAsync(d => d.Id == id);
            return dog;
        }

        public async Task Create(DogModel dogModel)
        {
            var dog = new Dog()
            {
                Id = dogModel.Id,
                Name = dogModel.Name, 
                Photo= dogModel.Photo,
                Phone= dogModel.Phone,
                Age = dogModel.Age,
            };
            await _context.Dogs.AddAsync(dog);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var dog = await _context.Dogs.FirstOrDefaultAsync(d => d.Id == id);
            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DogModel dogModel)
        {
            var dog =  await _context.Dogs.FirstOrDefaultAsync(d => d.Id == dogModel.Id);
            if (dog != null)
            {
                dog.Name = dogModel.Name;
                dog.Photo = dogModel.Photo;
                dog.Phone = dogModel.Phone;
                dog.Age = dogModel.Age;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dog>> GetAll()
        {
            var dogs =await _context.Dogs.ToListAsync();
            return dogs;
        }
    }
}