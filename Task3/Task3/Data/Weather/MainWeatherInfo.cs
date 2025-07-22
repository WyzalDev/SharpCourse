// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    public class MainWeatherInfo
    {
        [JsonProperty("temp")] public double Temp { get; set; }

        [JsonProperty("feels_like")] public double FeelsLike { get; set; }

        [JsonProperty("temp_min")] public double TempMin { get; set; }

        [JsonProperty("temp_max")] public double TempMax { get; set; }

        [JsonProperty("pressure")] public int Pressure { get; set; }

        [JsonProperty("humidity")] public double Humidity { get; set; }

        [JsonProperty("sea_level")] public double SeaLevel { get; set; }

        [JsonProperty("grnd_level")] public double GroundLevel { get; set; }
    }
}