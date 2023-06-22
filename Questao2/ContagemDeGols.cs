using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Questao2
{
    internal class ContagemDeGols
    {
        public static Dictionary<string, int> CalcularGolsPorTime(int ano)
        {
            string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={ano}";
            HttpClient httpClient = new HttpClient();
            List<string> times = new List<string>();
            Dictionary<string, int> golsPorTime = new Dictionary<string, int>();

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            string json = response.Content.ReadAsStringAsync().Result;
            JObject data = JsonConvert.DeserializeObject<JObject>(json);
            int totalPages = 0;

            if (data != null && data["total_pages"] != null)
            {
                totalPages = (int)data["total_pages"];
            }
            else
            {
                // Tratar caso data seja nulo ou total_pages seja nulo
            }

            for (int page = 1; page <= totalPages; page++)
            {
                response = httpClient.GetAsync($"{url}&page={page}").Result;
                json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<JObject>(json);

                foreach (var partida in data["data"])
                {
                    string time1 = partida["team1"]?.ToString() ?? "";
                    string time2 = partida["team2"]?.ToString() ?? "";

                    if (!times.Contains(time1))
                        times.Add(time1);
                    if (!times.Contains(time2))
                        times.Add(time2);

                    int golsTime1 = partida["team1goals"]?.Value<int>() ?? 0;
                    int golsTime2 = partida["team2goals"]?.Value<int>() ?? 0;

                    if (golsPorTime.ContainsKey(time1))
                        golsPorTime[time1] += golsTime1;
                    else
                        golsPorTime[time1] = golsTime1;
                    if (golsPorTime.ContainsKey(time2))
                        golsPorTime[time2] += golsTime2;
                    else
                        golsPorTime[time2] = golsTime2;
                }
            }

            return golsPorTime;
        }
    }
}