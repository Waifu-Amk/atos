using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;

namespace Ventas.WebApi.Models
{
    public class ProductSearcher
    {



        public async Task<Product> GetProductAsync(int id)
        {
            using (var HttpClientHandler = new HttpClientHandler())
            {
                HttpClientHandler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) => {
                    return true; };
                using (var client = new HttpClient(HttpClientHandler))
                {
                    HttpResponseMessage response = await client.GetAsync($"https://Catalogo.WebApi_1:443/api/Productos/{id}");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    Product product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(responseBody);

                    return product;
                }
            }

        }
    }
}
