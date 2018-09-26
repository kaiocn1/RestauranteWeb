using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestauranteWeb.CrossCutting.Utils
{
    public class JsonToObject<T>
    {
        public static async Task<T> Convert(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
