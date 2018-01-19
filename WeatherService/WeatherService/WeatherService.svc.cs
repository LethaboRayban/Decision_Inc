using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherService
{
    public class WeatherService : IWeatherService
    {
        WeatherContext db; 

        public WeatherService()
        {
            db = new WeatherContext(); 
        }
        public List<City> GetAllWeather()
        {
            try
            {
                List<City> CityList = db.City.ToList();
                return CityList;
            }
            catch(Exception ex)
            {
                //safe fail
                return new List<City>(); 
            }
           
        }

        public bool AddWeatherByCity(City c)
        {
            try
            {
                db.City.Add(c);
                db.SaveChanges();
                return true; 
            }
            catch(Exception ex)
            {
                return false; 
            }
           
        }

        public List<City> GetWeatherByCity(List<int> ids)
        {
            List<City> allCities = db.City.ToList();
            try
            {
                List<City> result = new List<City>();

                foreach (var city in allCities)
                {
                    foreach (var id in ids)
                    {
                        if (city.Id == id)
                            result.Add(city);
                    }
                }

                return result;
            }
            catch(Exception ex)
            {
                //safe fail
                return allCities; 
            }
        }

        internal class Context
        {
        }
    }
}
