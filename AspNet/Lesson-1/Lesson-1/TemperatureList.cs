using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1
{
    public class TemperatureList
    {
        public List<WeatherForecast> WeatherForecasts { get; set; }
        
        internal void Add(WeatherForecast weatherForecast)
        {
            WeatherForecasts.Add(weatherForecast);
        }
        internal List<WeatherForecast> Get (DateTime startTime, DateTime endTime)
        {
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            for (int i = 0; i < WeatherForecasts.Count; i++)
            {
                if (WeatherForecasts[i].Date <= endTime && WeatherForecasts[i].Date >= startTime)
                    resultList.Add(WeatherForecasts[i]);
               
            }
            return resultList;

        }
        internal void Update(DateTime currentTime, int newTemperature)
        {
            for (int i = 0; i < WeatherForecasts.Count; i++)
            {
                if (WeatherForecasts[i].Date == currentTime )
                    WeatherForecasts[i].TemperatureC = newTemperature;

            }
        }
        internal void Delete(DateTime startTime, DateTime endTime)
        {
            for (int i = 0; i < WeatherForecasts.Count; i++)
            {
                if (WeatherForecasts[i].Date <= endTime && WeatherForecasts[i].Date >= startTime)
                    WeatherForecasts.Remove(WeatherForecasts[i]);

            }
           

        }
    }
}
