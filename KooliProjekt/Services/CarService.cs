using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace KooliProjekt.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _dbContext;

        public CarService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task Delete(int? id)
        {
            if (id == null || _dbContext.Car == null)
            {
                return;
            }

            var car = await _dbContext.Car
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return;
            }

            _dbContext.Remove(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Car> Get(int? id)
        {
            if (id == null || _dbContext.Car == null)
            {
                return null;
            }

            return await _dbContext.Car.FirstOrDefaultAsync(m => m.ID == id);
            
        }

        public Task Save(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
