using KooliProjekt.Data;
using Microsoft.Build.Evaluation;

namespace KooliProjekt.Services
{
    public interface ICarService
    {
        Task<Car> Get(int? id);
        Task Delete(int? id);
        Task Save(Car car);
    }
}
