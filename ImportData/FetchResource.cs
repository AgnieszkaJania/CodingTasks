using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessData
{
    public static class FetchResource
    {
        public static async Task<string> FetchResourceAsync(string address)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(address);
                    var data = await response.Content.ReadAsStringAsync();
                    return data;
                }
            }
            catch(HttpRequestException ex)
            {
                return ex.Message;
            }
        }
        public static List<Rate> DeserializeRates(string json)
        {
            var rates = JsonConvert.DeserializeObject<List<ExchangeRate>>(json);
            return rates.First().Rates;
        }  
    }
}
