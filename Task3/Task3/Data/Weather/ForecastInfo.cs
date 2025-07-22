// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text;
using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    public class ForecastInfo
    {
        [JsonProperty("cod")] public int Code { get; set; }

        [JsonProperty("cnt")] public int Count { get; set; }

        [JsonProperty("list")] public List<ForecastElement> ForecastList { get; set; }

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