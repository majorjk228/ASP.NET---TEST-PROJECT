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

                    HRoot myDeserializedClass = JsonConvert.DeserializeObject<HRoot>(jsonString);

                    var map = new MappingProfile();

                    foreach (var item in map.GetHouse(myDeserializedClass.houses))
                    {
                        dataManager.Houses.SaveHouse(item);
                    }
                                      
                    return Ok("Файл успешно обработан \n" + jsonObject);
                }
            }
            else
            {
                ModelState.AddModelError("jsonFile", "Выберите файл JSON для загрузки");
                //return Error("Фaйл не выбран");            
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

        // GET: HouseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HouseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HouseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HouseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HouseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
