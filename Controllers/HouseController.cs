using Microsoft.AspNetCore.Mvc;
using System;
using TEST_TPLUS.Domain.Entities;
using TEST_TPLUS.Domains;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.DotNet.MSIdentity.Shared;
using System.Xml.Linq;
using static TEST_TPLUS.Controllers.HouseController;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;

namespace TEST_TPLUS.Controllers
{
    public class HouseController : Controller
    {
        private readonly DataManager dataManager; // Для того, чтобы иметь доступ к базе данных

        private readonly AppDbContext context;

        public HouseController(DataManager dataManager, AppDbContext context)
        {
            this.dataManager = dataManager;
            this.context = context;
        }

        // GET: HouseController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(IFormFile jsonFile)
        {
            if (jsonFile != null && jsonFile.Length > 0)
            {   // Обработка файла
                using (var reader = new StreamReader(jsonFile.OpenReadStream()))
                {
                    var jsonString = reader.ReadToEnd();
                    var jsonObject = JObject.Parse(jsonString);

                    var map = new MappingProfile();

                    HRoot? houser = JsonConvert.DeserializeObject<HRoot>(jsonString);     
                    
                    // Сейвим в БД все, что связано с домами
                    foreach (var item in map.GetHouse(houser.Houses))
                    {
                        dataManager.Houses.SaveHouse(item);
                    }

                    PRoot? plantser = JsonConvert.DeserializeObject<PRoot>(jsonString);

                    // Сейвим в БД все, что связано с заводами
                    foreach (var item in map.GetPlant(plantser.Plants))
                    {
                        dataManager.Plants.SavePlant(item);
                    }

                    return Ok("Файл успешно обработан \n" + jsonObject);
                }
            }
            else
            {
                ModelState.AddModelError("jsonFile", "Выберите файл JSON для загрузки");
                //return Error("Фaйл не выбран");    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });     
                return View("Index");
            }
        }

        public IActionResult DownloadFile()
        {
            // Путь к файлу
            string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/test.json");
            // Тип файла - content-type
            string file_type = "text/plain";
            // Имя файла - необязательно
            string file_name = "test.json";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
