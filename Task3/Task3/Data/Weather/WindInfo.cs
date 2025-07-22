// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    public class WindInfo
    {
        [JsonProperty("speed")] public double Speed { get; set; }

        [JsonProperty("deg")] public int Deg { get; set; }

        [JsonProperty("gust")] public double Gust { get; set; }
    }
}