using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeeatherReference;



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

                WeatherServiceWeatherVM[] allCities = await client.GetAllWeatherAsync();
   
                
                
                return Json(allCities.ToList());
            }
            catch(Exception ex)
            {
                return Json(new List<WeatherServiceWeatherVM>()); 
            }
           
         }

        public async Task<JsonResult> GetWeatherByCity(List<int> ids){

            try
            {
                WeatherServiceClient client = new WeatherServiceClient();

                WeatherServiceWeatherVM[] filteredCities = await client.GetWeatherByCityAsync(ids.ToArray());

                return Json(filteredCities);
            }
            catch(Exception ex)
            {
                return Json(GetAllWeather()); 
            }
        }
    }
}
