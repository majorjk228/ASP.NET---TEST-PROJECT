﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEST_TPLUS.Domain.Entities;
using TEST_TPLUS.Domain.Repositories.Abstract;
using TEST_TPLUS.Domains;

// Реализация методов, объявленных в интефрейсе
namespace TEST_TPLUS.Domain.Repositories.EntityFramework
{
    public class EFPlantsRepository : IPlantsRepository
    {
        private readonly AppDbContext context;
        public EFPlantsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Plant> GetPlant()
        {
            return context.Plants;
        }

        public IQueryable<Plant> GetIncludePlant()                // все заводы + консумшены
        {
            return context.Plants.Include(o => o.Consumptions);
        }

        public Plant GetPlantById(int id)
        {
            return context.Plants.FirstOrDefault(x => x.ConsumerId == id);
        }

        public void SavePlant(Plant entity)
        {
            context.Plants.Add(entity);
            context.SaveChanges();            
        }

        public void DeletePlant(int id)
        {
            context.Plants.Remove(new Plant() { ConsumerId = id });
            context.SaveChanges();
        }
    }
}
