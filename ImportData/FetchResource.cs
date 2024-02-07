using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

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
        public static List<Rate> DeserializeRatesFromXml(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            List<Rate> rates = new List<Rate>();
            xmlDoc.LoadXml(xml);
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[3].ChildNodes)
            {
                rates.Add(new Rate { Currency = node.ChildNodes[0].InnerText, Code = node.ChildNodes[1].InnerText,
                     Mid = decimal.Parse(node.ChildNodes[2].InnerText, NumberFormatInfo.InvariantInfo)
                });
            }
            return rates;
        }
    }
}
