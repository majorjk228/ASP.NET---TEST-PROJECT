using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TEST_TPLUS.Domain.Entities;
using TEST_TPLUS.Domains;
using TEST_TPLUS.Domains.Repositories.Abstract;
using static System.Web.Razor.Parser.SyntaxConstants;


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

        public List<House> GetHouse()                               // все записи из таблицы
        {
            return context.Houses.ToList();
        }

        public IQueryable<House> GetIncludeHouse()                // все дома + консумшены
        {
            return context.Houses.Include(o => o.Consumptions);
        }

        public House GetHouseById(int id)                           // конкретного по айди
        {
            return context.Houses.FirstOrDefault(x => x.ConsumerId == id);
        }

        public House GetHouseByName(string name)                    // по наименованию
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
