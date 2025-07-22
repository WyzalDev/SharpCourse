// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using Newtonsoft.Json;

namespace Task3.Data
{
    public class CityInfo
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("lat")] public double Lat { get; set; }

        [JsonProperty("lon")] public double Lon { get; set; }

        [JsonProperty("country")] public string Country { get; set; }

        public int Code { get; set; }
    }
}