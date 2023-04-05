using Microsoft.EntityFrameworkCore;
using TEST_TPLUS.Domain.Entities;
using TEST_TPLUS.Domains;
using TEST_TPLUS.Domains.Repositories.Abstract;


// Реализация методов, объявленных в интефрейсе
namespace TEST_TPLUS.Domain.Repositories.EntityFramework
{
    public class EFHousesRepository : IHousesRepository
    {
        private readonly AppDbContext context;

        public EFHousesRepository(AppDbContext context)
        {
            this.context = context;            
        }

        public IQueryable<House> GetHouse()                         // все записи из таблицы
        {
            return context.Houses;
        }

        public House GetHouseById(int id)                           // первая запись из таблицы
        {
            return context.Houses.FirstOrDefault(x => x.ConsumerId == id);
        }

        public House GetHouseByName(string name)                    // по ключевому полю из таблицы
        {
            return context.Houses.FirstOrDefault(x => x.Name == name);
        }

        public void SaveHouse(House entity)                         // Сохраняем
        {
            context.Houses.Add(entity);
            context.SaveChanges();                                 
        }

        public void DeleteHouse(int id)                             // Удаляем текстовое поля из БД
        {
            context.Houses.Remove(new House() { ConsumerId = id });     // необходим идентификатор
            context.SaveChanges();
        }
    }
}
