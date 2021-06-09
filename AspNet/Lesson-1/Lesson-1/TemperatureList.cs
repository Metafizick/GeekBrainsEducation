using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1
{
    public class TemperatureList
    {
        public List<WeatherForecast> weatherForecasts { get; set; }
        public TemperatureList()
        {

        }
        internal void Add(WeatherForecast weatherForecast)
        {
            weatherForecasts.Add(weatherForecast);
        }
        internal List<WeatherForecast> Get (DateTime startTime, DateTime endTime)
        {
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            for (int i = 0; i < weatherForecasts.Count; i++)
            {
                if (weatherForecasts[i].Date <= endTime && weatherForecasts[i].Date >= startTime)
                    resultList.Add(weatherForecasts[i]);
               
            }
            return resultList;

        }
        internal void Update(DateTime currentTime, int newTemperature)
        {
            for (int i = 0; i < weatherForecasts.Count; i++)
            {
                if (weatherForecasts[i].Date == currentTime )
                    weatherForecasts[i].TemperatureC = newTemperature;

            }
        }
        internal void Delete(DateTime startTime, DateTime endTime)
        {
            for (int i = 0; i < weatherForecasts.Count; i++)
            {
                if (weatherForecasts[i].Date <= endTime && weatherForecasts[i].Date >= startTime)
                    weatherForecasts.Remove(weatherForecasts[i]);

            }
           

        }
    }
}
