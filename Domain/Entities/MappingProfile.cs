using System;

namespace TEST_TPLUS.Domain.Entities
{
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
                    Consumptions = GetCons(item.Consumptions)
                }
                );
            }

            return list;
        }

        public List<HouseConsumption> GetCons(IReadOnlyCollection<HouseConsumption> Consumptions)
        {
            var list = new List<HouseConsumption>();

            foreach (var item in Consumptions)
            {
                list.Add(new HouseConsumption
                {
                    Weather = 17,
                    Consumption = 10
                }
                );
            }

            return list;
        }
    }
}
