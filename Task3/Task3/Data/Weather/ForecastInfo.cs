// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    [Serializable]
    public class ForecastInfo
    {
        [JsonProperty("cnt")] public int Count { get; set; }

        [JsonProperty("list")] public List<ForecastElement> ForecastList { get; set; }

        [JsonProperty("cod")]
        public int Code
        {
            get => _code;
            set => _code = value;
        }

        [NonSerialized] private int _code;

        public override string ToString()
        {
            var s = new StringBuilder();

            for (var i = 0; i < Count; i++)
            {
                s.AppendLine(
                    "———————————————————————————————————————————————————————————————————————————————————————————————");

                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                s.AppendLine($"{i + 1}. Time - {dateTime.AddSeconds(ForecastList[i].UnixTime).ToLocalTime()}");
                s.AppendLine($"{ForecastList[i].ToString()}");
            }

            s.AppendLine(
                "———————————————————————————————————————————————————————————————————————————————————————————————");

            return s.ToString();
        }
    }
}