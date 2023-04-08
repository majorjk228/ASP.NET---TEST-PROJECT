using System;
using System.Linq;
using TEST_TPLUS.Domain.Entities;


// Репозитории для манипуляции над объектами house интерфейс
// Здесь мы можем делать выборку из бд с помощью EF Core
namespace TEST_TPLUS.Domains.Repositories.Abstract
{
    public interface IHousesRepository
    {
        List<House> GetHouse(); // Получаем все дома
        IQueryable<House> GetIncludeHouse(); // Получаем все дома
        House GetHouseById(int id);  // Выбрать дом по айди   
		House GetHouseByName(string name); // Выбрать дом по названию
        void SaveHouse(House entity); // Сохранить
        void DeleteHouse(int id);   // Удалить дом
    }
}
