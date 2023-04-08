using TEST_TPLUS.Domain.Entities;
using TEST_TPLUS.Domain.Repositories.Abstract;
using TEST_TPLUS.Domains.Repositories.Abstract;

// Класс помощник - Централизванный класс, в котором содержится управление нашими репозиториями
namespace TEST_TPLUS.Domains
{
    public class DataManager
    {
        public IHousesRepository Houses { get; set; }
        public IPlantsRepository Plants { get; set; }

        public DataManager(IHousesRepository housesRepository, IPlantsRepository factoriesRepository)
        {
            Houses = housesRepository;
            Plants = factoriesRepository;
        }
    }
}
