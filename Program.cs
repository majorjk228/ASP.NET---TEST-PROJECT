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

// ���������� ������ �� appsetings.json
builder.Configuration.Bind("Project", new Config());

// �������� ������ ����������� �� ������ Config
var connectionString = Config.ConnectionString;

// ���������� ������ ���������� ���������� � �������� ��������
builder.Services.AddTransient<IHousesRepository, EFHousesRepository>(); // ���� ����� �������� �� �� ������ ����� �������� EF...Reps �� ����� ������ ��.
builder.Services.AddTransient<IPlantsRepository, EFPlantsRepository>();
builder.Services.AddTransient<DataManager>();

// ��������� �������� ApplicationContext � �������� ������� � ����������
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

// ���������� ��������� ��������� ������ � ���������� (css, js � �.�.)
app.UseStaticFiles();

app.UseRouting();

// �������������� � �����������
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

// ������������ ������ �������� (���������)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
