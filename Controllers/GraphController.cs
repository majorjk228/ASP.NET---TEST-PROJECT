using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using TEST_TPLUS.Domains;

namespace TEST_TPLUS.Controllers
{
    public class GraphController : Controller
    {
        private readonly DataManager dataManager;

        private readonly AppDbContext context;

        public GraphController(DataManager dataManager, AppDbContext context)
        {
            this.dataManager = dataManager;
            this.context = context;
        }

        public record Houses(string Name, List<double> Consumption);
        public record Plants(string Name, List<double> Consumption);

        [HttpGet]
        public ActionResult GetHouses()
        {
            var response = dataManager.Houses.GetIncludeHouse();

            // Выводим Дома, Сгруппированная Погода, Суммированное Потребление
            var query = from house in context.Houses
                        join cons in context.HouseConsumptions on house.ConsumerId equals cons.HouseConsumerId into houseCons
                        from hcons in houseCons.DefaultIfEmpty()
                        group hcons by new { house.Name, hcons.Weather } into g
                        select new
                        {
                            g.Key.Name,
                            Weather = g.Key.Weather,
                            Consumption = g.Sum(x => x.Consumption)
                        };

            List<Houses> houses = new List<Houses>();

            var resp = query.ToList();

            foreach (var item in response)
            {
                houses.Add(new Houses
                (
                    item.Name,
                    resp.Where(x => x.Name == item.Name).Select(x => x.Consumption).ToList()
                )
                ); 
            }            

            return View("HouseView", houses);
        }

        [HttpGet("api/weather")]
        public ActionResult GetWeather()
        {

            var result = context.HouseConsumptions.Select(c => c.Weather).Distinct().OrderBy(w => w);

            if (result is null)
            {
                return NotFound();
            }

            string json = JsonConvert.SerializeObject(result);
            return Ok(json);
        }


        [HttpGet]
        public ActionResult GetPlants()
        {
            var response = dataManager.Plants.GetIncludePlant();

            // Выводим Дома, Сгруппированная Погода, Суммированное Потребление
            var query = from plant in context.Plants
                        join cons in context.PlantConsumptions on plant.ConsumerId equals cons.PlantConsumerId into plantCons
                        from pcons in plantCons.DefaultIfEmpty()
                        group pcons by new { plant.Name, pcons.Price } into g
                        select new
                        {
                            g.Key.Name,
                            Price = g.Key.Price,
                            Consumption = g.Sum(x => x.Consumption)
                        };

            List<Plants> plants = new List<Plants>();

            var resp = query.ToList();

            foreach (var item in response)
            {
                plants.Add(new Plants
                (
                    item.Name,
                    resp.Where(x => x.Name == item.Name).Select(x => x.Consumption).ToList()
                )
                );
            }

            return View("PlantsView", plants);
        }



        [HttpGet("api/price")]
        public ActionResult GetPrice()
        {

            var result = context.PlantConsumptions.Select(c => c.Price).Distinct().OrderBy(w => w);

            if (result is null)
            {
                return NotFound();
            }

            string json = JsonConvert.SerializeObject(result);
            return Ok(json);
        }

    }
}
