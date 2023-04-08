using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TEST_TPLUS.Domain.Entities;
using TEST_TPLUS.Domains;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
       
        public record Houses(string Name, double Weather, double Consumption);

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

            foreach (var item in resp)
            {
                houses.Add(new Houses
                (
                    item.Name,
                    item.Weather,
                    item.Consumption
                )
                );
            }


            return View(response);
        }

        public ActionResult StandardBar()
        {
            return View();
        }

        [HttpGet("api/houses")]
        public ActionResult GetByApi()
        {
            //var resp = dataManager.Houses.GetHouse();

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

    }
}
