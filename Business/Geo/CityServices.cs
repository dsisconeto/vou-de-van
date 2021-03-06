﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business.Geo
{
    public class CityServices
    {
        private readonly DataBaseContext _dataBaseContext;

        public CityServices(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public List<City> FindAll(string term = "")
        {
            return _dataBaseContext.Cities
                .Include(c => c.State)
                .Where(c => c.Name.Contains(term) || c.State.Initials.Contains(term))
                .OrderByDescending(tc => tc.CreatedAt)
                .Take(10)
                .ToList();
        }
    }
}