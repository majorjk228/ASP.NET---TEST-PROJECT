using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TEST_TPLUS.Domain.Entities;
using TEST_TPLUS.Domain.Repositories.Abstract;
using TEST_TPLUS.Domain.Repositories.EntityFramework;
using TEST_TPLUS.Domains;
using TEST_TPLUS.Domains.Repositories.Abstract;
using TEST_TPLUS.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// подключаем конфиг из appsetings.json
builder.Configuration.Bind("Project", new Config());

// получаем строку подключения из Класса Config
var connectionString = Config.ConnectionString;

// Подключаем нужный функционал приложения в качестве сервисов
builder.Services.AddTransient<IHousesRepository, EFHousesRepository>(); // Если хотим поменять БД то просто можем поменять EF...Reps на любую другую БД.
builder.Services.AddTransient<IPlantsRepository, EFPlantsRepository>();
builder.Services.AddTransient<DataManager>();

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Подключаем поддержку статичных файлов в приложении (css, js и т.д.)
app.UseStaticFiles();

app.UseRouting();

// Аутентификация и авторизация
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

// Регистрируем нужные маршруты (ендпоинты)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
