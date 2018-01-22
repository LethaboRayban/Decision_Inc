using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherReference;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherServiceApp.Controllers
{
    public class WeatherController : Controller
    {

        public async Task<JsonResult> GetAllWeather()
        {
            try
            {
                WeatherServiceClient client = new WeatherServiceClient();

                City[] allCities = await client.GetAllWeatherAsync();

                return Json(allCities);
            }
            catch(Exception ex)
            {
                return Json(new List<City>()); 
            }
           
         }

        public async Task<JsonResult> GetWeatherByCity(int[] ids){

            try
            {
                WeatherServiceClient client = new WeatherServiceClient();

                City[] filteredCities = await client.GetWeatherByCityAsync(ids);

                return Json(filteredCities);
            }
            catch(Exception ex)
            {
                return Json(GetAllWeather()); 
            }
        }
    }
}
