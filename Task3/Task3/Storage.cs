// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using Task3.Data.Weather;
using Task3.Utils;

namespace Task3
{
    public class Storage : IDisposable
    {
        public ObservableDictionary<string, AllWeatherInfo> WeatherInfos;
        public ObservableDictionary<string, ForecastInfo> ForecastInfos;

        private const string WeatherDataPath = "weather.txt";
        private const string ForecastDataPath = "forecast.txt";

        public void Instantiate()
        {
            LoadWeather();

            WeatherInfos ??= new ObservableDictionary<string, AllWeatherInfo>();
            ForecastInfos ??= new ObservableDictionary<string, ForecastInfo>();

            WeatherInfos.DictionaryChanged += SaveWeather;
            ForecastInfos.DictionaryChanged += SaveForecast;
        }

        private void SaveWeather()
        {
            FileSaveLoader.Save(WeatherInfos, WeatherDataPath);
        }

        private void SaveForecast()
        {
            FileSaveLoader.Save(ForecastInfos, ForecastDataPath);
        }

        private void LoadWeather()
        {
            WeatherInfos = FileSaveLoader.Load<ObservableDictionary<string, AllWeatherInfo>>(WeatherDataPath);
            ForecastInfos = FileSaveLoader.Load<ObservableDictionary<string, ForecastInfo>>(ForecastDataPath);
        }

        public void Dispose()
        {
            if (WeatherInfos != null && WeatherInfos.DictionaryChanged != null)
                WeatherInfos.DictionaryChanged -= SaveWeather;

            if (ForecastInfos != null && ForecastInfos.DictionaryChanged != null)
                ForecastInfos.DictionaryChanged -= SaveForecast;
        }
    }
}