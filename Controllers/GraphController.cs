using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
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

        [HttpGet]
        public ActionResult Index()
        {
            var resp = dataManager.Houses.GetIncludeHouse();

            /*var query = from house in context.Houses
                        join cons in context.HouseConsumptions on house.ConsumerId equals cons.House into houseCons;
                        //from hcons in houseCons.DefaultIfEmpty()
                        group houseCons by new { house.Name, houseCons.Weather } into g
                        select new
                        {
                            g.Key.Name,
                            Weather = g.Key.Weather ?? "N/A",
                            Consumption = g.Sum(x => x.Consumption)
                        };*/
       /*     var result = from house in context.Houses
                         join houseCons in context.HouseConsumptions
                            on house.ConsumerId equals houseCons.HouseConsumerId into houseConsGroup
                         from houseConsumption in houseConsGroup.DefaultIfEmpty()
                         select new
                         {
                             Name = house.Name,
                             Weather = houseConsumption.Weather,
                             Consumption = houseConsumption.Consumption
                         };*/

            return View(resp);
        }

        public ActionResult StandardBar()
        {
            return View();
        }

        [HttpGet("api/houses")]
        public ActionResult GetById()
        {
            var resp = dataManager.Houses.GetHouse();

            if (resp is null)
            {
                return NotFound();
            }

            string json = JsonConvert.SerializeObject(resp);
            return Ok(json);
        }

    }
}
