// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task3.Data;
using Task3.Data.Weather;

namespace Task3
{
    public static class WeatherDownloads
    {
        private const string OpenWeatherMapApiKey = "3ccec85d602098c4854bd68fa62f430c";

        private static readonly HttpClient Client = new HttpClient();

        public static async Task<CityInfo?> DownloadCityInfoByName(string city)
        {
            var result = await Client.GetAsync(
                $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={OpenWeatherMapApiKey}");

            var cityInfo = new CityInfo();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                cityInfo.Code = int.Parse(result.StatusCode.ToString());
                return cityInfo;
            }

            cityInfo = JsonConvert.DeserializeObject<List<CityInfo>>(
                await result.Content.ReadAsStringAsync())?[0];

            if (cityInfo != null)
                cityInfo.Code = 200;

            return cityInfo;
        }

        public static async Task<AllWeatherInfo?> DownloadWeather(CityInfo cityInfo)
        {
            var result = await Client.GetAsync(
                $"https://api.openweathermap.org/data/2.5/weather?lat={cityInfo.Lat}&lon={cityInfo.Lon}&appid={OpenWeatherMapApiKey}");

            var allWeatherInfo = new AllWeatherInfo();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                allWeatherInfo.Code = int.Parse(result.StatusCode.ToString());
                return allWeatherInfo;
            }

            allWeatherInfo = JsonConvert.DeserializeObject<AllWeatherInfo>(
                await result.Content.ReadAsStringAsync());

            return allWeatherInfo;
        }

        public static async Task<ForecastInfo?> DownloadForeCast(CityInfo cityInfo)
        {
            var result = await Client.GetAsync(
                $"https://api.openweathermap.org/data/2.5/forecast?lat={cityInfo.Lat}&lon={cityInfo.Lon}&appid={OpenWeatherMapApiKey}");

            var forecastInfo = new ForecastInfo();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                forecastInfo.Code = int.Parse(result.StatusCode.ToString());
                return forecastInfo;
            }

            forecastInfo = JsonConvert.DeserializeObject<ForecastInfo>(
                await result.Content.ReadAsStringAsync());

            return forecastInfo;
        }
    }
}