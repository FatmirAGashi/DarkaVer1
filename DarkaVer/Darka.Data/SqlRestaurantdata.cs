﻿using System.Collections.Generic;
using Darka.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Darka.Data
{
    public class SqlRestaurantdata : IRestaurantData
    {
        private readonly DarkaDbContext db;

        public SqlRestaurantdata(DarkaDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetByID(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetByID(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
