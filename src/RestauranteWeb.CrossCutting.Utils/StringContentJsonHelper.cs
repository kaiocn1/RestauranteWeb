using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace RestauranteWeb.CrossCutting.Utils
{
    public static class StringContentJsonHelper
    {
        public static StringContent ToJon(this object objeto)
        {
            var content = JsonConvert.SerializeObject(objeto);
            return new StringContent(content, Encoding.UTF8, "application/json");
        }
    }
}
