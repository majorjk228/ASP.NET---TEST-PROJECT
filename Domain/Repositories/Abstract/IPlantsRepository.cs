using System;
using System.Linq;
using TEST_TPLUS.Domain.Entities;

namespace TEST_TPLUS.Domain.Repositories.Abstract
{
    public interface IPlantsRepository
    {
        IQueryable<Plant> GetPlant();
        IQueryable<Plant> GetIncludePlant();
        Plant GetPlantById(int id);
        void SavePlant(Plant entity);
        void DeletePlant(int id);
    }
}
