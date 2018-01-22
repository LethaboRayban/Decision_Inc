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

        public class WeatherVM
        {

            public City City { get; set; }
            public string Image64 { get; set; }
        }

        public List<WeatherVM> GetAllWeather()
        {
            try
            {
                List<City> allCities = db.City.ToList();
               
                List<WeatherVM> result = new List<WeatherVM>();

                foreach(var city in allCities)
                {
                  
                    result.Add(new WeatherVM{

                        City = city,
                        Image64 = db.Image.FirstOrDefault(a => a.Id == city.ImageId).Photo.ToString()
                    });
                  
                }

                return result;
            }
            catch (Exception ex)
            {
                //safe fail
                return new List<WeatherVM>();
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
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<WeatherVM> GetWeatherByCity(List<int> ids)
        {

            try
            {
                List<City> allCities = db.City.ToList();
                List<WeatherVM> result = new List<WeatherVM>();

                foreach (var city in allCities)
                {
                    foreach (var id in ids)
                    {
                        if (city.Id == id)
                            result.Add(new WeatherVM
                            {

                                City = city,
                                Image64 = db.Image.SingleOrDefault(a => a.Id == city.ImageId).Photo.ToString()
                            });
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                //safe fail

                return new List<WeatherVM>();
            }
        }

       
        internal class Context
        {
        }
    }
}
