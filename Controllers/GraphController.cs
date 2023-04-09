using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public ActionResult Index()
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
            


            return View(houses);
        }

        public ActionResult StandardBar()
        {
            return View();
        }

        [HttpGet("api/houses")]
        public ActionResult GetByApi()
        {
            // Выводим Дома, Сгруппированная Погода, Суммированное Потребление
            var resp = from house in context.Houses
                       join cons in context.HouseConsumptions on house.ConsumerId equals cons.HouseConsumerId into houseCons
                       from hcons in houseCons.DefaultIfEmpty()
                       group hcons by new { house.Name, hcons.Weather } into g
                       select new
                       {
                           g.Key.Name,
                           Weather = g.Key.Weather,
                           Consumption = g.Sum(x => x.Consumption)
                       };

            if (resp is null)
            {
                return NotFound();
            }

            string json = JsonConvert.SerializeObject(resp);
            return Ok(json);
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

    }
}
