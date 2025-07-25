// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    [Serializable]
    public class ForecastElement
    {
        [JsonProperty("dt")] public long UnixTime { get; set; }

        [JsonProperty("main")] public MainWeatherInfo Main { get; set; }

        [JsonProperty("weather")] public List<WeatherInfo> Weather { get; set; }

        [JsonProperty("clouds")] public CloudsInfo Clouds { get; set; }

        [JsonProperty("wind")] public WindInfo Wind { get; set; }

        [JsonProperty("visibility")] public int Visibility { get; set; }

        [JsonProperty("rain")] public PrecipitationInfo3h Rain { get; set; }

        [JsonProperty("snow")] public PrecipitationInfo3h Snow { get; set; }

        public override string ToString()
        {
            var s = new StringBuilder();

            s.AppendLine($"Temperature: {Main.Temp}");
            s.AppendLine($"Temperature feels like: {Main.FeelsLike}");
            s.AppendLine($"Max Temperature: {Main.TempMax}");
            s.AppendLine($"Min Temperature: {Main.TempMin}");

            s.AppendLine($"\n\r{Weather[0].Main} - {Weather[0].Description}");

            if (Rain != null)
                s.AppendLine($"Rain 3h - {Rain.ThreeHours} mm/h");

            if (Snow != null)
                s.AppendLine($"Snow 3h - {Snow.ThreeHours} mm/h");

            s.AppendLine($"\n\rCloudness - {Clouds.All} %");

            s.AppendLine($"\n\rWind Speed: {Wind.Speed} meter/sec");
            s.AppendLine($"Wind direction: {Wind.Deg} degrees");
            s.AppendLine($"Wind gust: {Wind.Gust} meter/sec");

            s.AppendLine($"\n\rPressure: {Main.Pressure} hPa");
            s.AppendLine($"Ground Level Pressure: {Main.GroundLevel} hPa");
            s.AppendLine($"Sea Level Pressure: {Main.SeaLevel} hPa");

            s.AppendLine($"\n\rHumidity: {Main.Humidity} %");

            s.AppendLine($"\n\rVisibility: {Visibility} meters");

            return s.ToString();
        }
    }
}