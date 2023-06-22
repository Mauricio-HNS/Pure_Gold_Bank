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
            string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={ano}"; // URL da API com o filtro de ano
            HttpClient httpClient = new HttpClient();
            List<string> times = new List<string>(); // lista de times que jogaram no ano
            Dictionary<string, int> golsPorTime = new Dictionary<string, int>(); // dicionário que armazenará a contagem de gols por time

            // realiza a primeira requisição para obter o número total de páginas de resultados
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            string json = response.Content.ReadAsStringAsync().Result;
            JObject data = JsonConvert.DeserializeObject<JObject>(json);
            int totalPages = (int)data["total_pages"];

            // percorre todas as páginas de resultados
            for (int page = 1; page <= totalPages; page++)
            {
                // realiza a requisição para a página atual
                response = httpClient.GetAsync($"{url}&page={page}").Result;
                json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<JObject>(json);

                // percorre todas as partidas da página atual
                foreach (var partida in data["data"])
                {
                    // obtém o nome dos times que jogaram na partida
                    string time1 = partida["team1"].ToString();
                    string time2 = partida["team2"].ToString();

                    // se o time ainda não foi adicionado à lista de times que jogaram, adiciona
                    if (!times.Contains(time1))
                        times.Add(time1);
                    if (!times.Contains(time2))
                        times.Add(time2);

                    // obtém a quantidade de gols marcados por cada time na partida
                    int golsTime1 = int.TryParse(partida["team1goals"]?.ToString() ?? "0", out int result1) ? result1 : 0;
                    int golsTime2 = int.TryParse(partida["team2goals"]?.ToString() ?? "0", out int result2) ? result2 : 0;

                    // adiciona a quantidade de gols ao dicionário de contagem de gols por time
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

            // retorna o dicionário de contagem de gols por time
            return golsPorTime;
        }
    }
}