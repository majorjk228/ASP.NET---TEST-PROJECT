using System;

namespace TEST_TPLUS.Domain.Entities
{
    // Класс для орбаботки классов, после десериализации JSON
    public class MappingProfile
    {
        public List<House> GetHouse(List<House> houses)
        {
            var list = new List<House>();

            foreach (var item in houses)
            {
                list.Add(new House
                {
                    Name = item.Name,
                    UserName = "Alex",
                    Consumptions = GetHCons(item.Consumptions)
                }
                );
            }

            return list;
        }

        public List<HouseConsumption> GetHCons(IReadOnlyCollection<HouseConsumption> Consumptions)
        {
            var list = new List<HouseConsumption>();

            foreach (var item in Consumptions)
            {
                list.Add(new HouseConsumption
                {
                    Weather = item.Weather,
                    Consumption = item.Consumption
                }
                );
            }

            return list;
        }

        public List<Plant> GetPlant(List<Plant> plants)
        {
            var list = new List<Plant>();

            foreach (var item in plants)
            {
                list.Add(new Plant
                {
                    Name = item.Name,
                    UserName = "Alex",
                    Consumptions = GetPCons(item.Consumptions)
                }
                );
            }

            return list;
        }

        public List<PlantConsumption> GetPCons(IReadOnlyCollection<PlantConsumption> Consumptions)
        {
            var list = new List<PlantConsumption>();

            foreach (var item in Consumptions)
            {
                list.Add(new PlantConsumption
                {
                    Price = item.Price,
                    Consumption = item.Consumption
                }
                );
            }

            return list;
        }
    }
}
