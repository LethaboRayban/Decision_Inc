using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherService
{
    [ServiceContract]
    public interface IWeatherService
    {

        [OperationContract]
        List<City> GetAllWeather();

        [OperationContract]
        List<City> GetWeatherByCity(List<int> ids);

        [OperationContract]
        bool AddWeatherByCity(City c);

    }

    [DataContract]
    public class City
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Degree { get; set; }

        [DataMember]
        public string Condition { get; set; }
        [DataMember]
        public int ImageId { get; set; }
        
    }

    [DataContract]
    public class Image
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Photo { get; set; }
    }
}
