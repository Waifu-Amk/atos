using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tester.Models.Catalogo;
using Tester.Models.Venta;

namespace Tester
{
    public class Tester
    {
        public async Task TestProducts()
        {
            using (var HttpClientHanlder = new HttpClientHandler())
            {
                HttpClientHanlder.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) =>
                {
                    return true;
                };
                using (var HttpClient = new HttpClient(HttpClientHanlder)) {
                    ///////////////////////////////////////////////GETALL/////////////////////////////////////////////////
                    Console.WriteLine("Testing GetAll() Categoria");
                    Categoria categoriaTest = new Categoria();
                    HttpResponseMessage response = await HttpClient.GetAsync($"https://localhost:5000/api/Categorias");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    List<Categoria> categorias = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Categoria>>(responseBody);

                    foreach (var item in categorias)
                    {
                        Console.WriteLine($"-Id = {item.Id}, Name = {item.Name}");
                    }
                    ///////////////////////////////////////POST/////////////////////////////////////////////
                    Console.WriteLine("Testing POST Categoria");
                    Categoria categoriaPost = new Categoria();
                    categoriaPost.Id = 50;
                    categoriaPost.Name = "Carros";

                    Console.WriteLine($"Data POST: ID={categoriaPost.Id},NAME={categoriaPost.Name}");

                    string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(categoriaPost);
                    response = await HttpClient.PostAsync("https://localhost:5000/api/Categorias", 
                        new StringContent(jsonContent, Encoding.UTF8,"application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());

                    categoriaPost.Name = "Jugetes";
                    jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(categoriaPost);
                    ////////////////////////////////////////////PUT/////////////////////////////////////
                    Console.WriteLine($"Test PUT Method Name={categoriaPost.Name}");
                    response = await HttpClient.PutAsync($"https://localhost:5000/api/Categorias/{categoriaPost.Id}",
                        new StringContent(jsonContent, Encoding.UTF8,"application/json"));
                    response.EnsureSuccessStatusCode();

                    Console.WriteLine(response.StatusCode.ToString());
                    /////////////////////////////////////////////////////GET///////////////////////////////////////////////
                    Console.WriteLine("Testing GET method");
                    response = await HttpClient.GetAsync($"https://localhost:5000/api/Categorias/{categoriaPost.Id}");
                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();
                    categoriaTest = Newtonsoft.Json.JsonConvert.DeserializeObject<Categoria>(responseBody);

                    Console.WriteLine($"categoriaTest  Id={categoriaTest.Id}, Name={categoriaTest.Name}");
                    //////////////////////////////////////////////////DELETE//////////////////////////////////////////////////
                    Console.WriteLine("Testing DELETE method");
                    response = await HttpClient.DeleteAsync($"https://localhost:5000/api/Categorias?id={categoriaTest.Id}");
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString() +"\nTEST Categoria API Complete press any key");
                    
                    Console.ReadKey();

                    /////////////////////////////////////////////////GETALL////////////////////////////////////////////////
                    List<Marca> marcasTest = new List<Marca>();
                    Marca marcaTest = new Marca();
                    Console.WriteLine("Testing GetAll method");
                    response = await HttpClient.GetAsync("https://localhost:5000/api/Marcas");
                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();
                    marcasTest = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Marca>>(responseBody);
                    foreach (var item in marcasTest)
                    {
                        Console.WriteLine($"Id={item.Id}, Name={item.Name}, CategoriaId={item.CategoriaId}");
                    }
                    /////////////////////////////////////////////POST//////////////////////////////////////////
                    marcaTest.Id = 50;
                    marcaTest.Name = "Mercedes";
                    marcaTest.CategoriaId = 4;
                    jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(marcaTest);
                    Console.WriteLine($"Testing POST Method with ID={marcaTest.Id}, Name={marcaTest.Name}, CategoriaId={marcaTest.CategoriaId}");
                    response = await HttpClient.PostAsync("https://localhost:5000/api/Marcas",
                        new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());

                    /////////////////////////////////////////////PUT///////////////////////////////////////////////
                    marcaTest.Name = "Great Value";
                    marcaTest.CategoriaId = 6;
                    jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(marcaTest);
                    Console.WriteLine("Changing Marca Values from Id " + marcaTest.Id);
                    response = await HttpClient.PutAsync($"https://localhost:5000/api/Marcas/{marcaTest.Id}",
                            new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());
                    /////////////////////////////////////////////GET//////////////////////////////////////////////
                    Console.WriteLine("Testing GET method");
                    response = await HttpClient.GetAsync($"https://localhost:5000/api/Marcas/{marcaTest.Id}");
                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();
                    marcaTest = Newtonsoft.Json.JsonConvert.DeserializeObject<Marca>(responseBody);

                    Console.WriteLine($"Marca Test  Id={marcaTest.Id}, Name={marcaTest.Name}");
                    //////////////////////////////////////////////////DELETE//////////////////////////////////////////////////
                    Console.WriteLine("Testing DELETE method");
                    response = await HttpClient.DeleteAsync($"https://localhost:5000/api/Marcas?id={marcaTest.Id}");
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString() + "\nTEST Marca API Complete presss any key");

                    Console.ReadKey();


                    /////////////////////////////////////////////////GETALL////////////////////////////////////////////////
                    List<Producto>  productosTest = new List<Producto>();
                    Producto productoTest = new Producto();
                    Console.WriteLine("Testing GetAll method");
                    response = await HttpClient.GetAsync("https://localhost:5000/api/Productos");
                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();
                    productosTest = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(responseBody);
                    foreach (var item in productosTest)
                    {
                        Console.WriteLine($"Id={item.Id}, Name={item.Name}, CategoriaId={productoTest.MarcaId}");
                    }
                    /////////////////////////////////////////////POST//////////////////////////////////////////
                    productoTest.Id = 50;
                    productoTest.Name = "SL600";
                    productoTest.MarcaId = 5;
                    jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(productoTest);
                    Console.WriteLine($"Testing POST Method with ID={productoTest.Id}, Name={productoTest.Name}, CategoriaId={productoTest.MarcaId}");
                    response = await HttpClient.PostAsync("https://localhost:5000/api/Productos",
                        new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());

                    /////////////////////////////////////////////PUT///////////////////////////////////////////////
                    productoTest.Name = "Ricolino";
                    productoTest.MarcaId = 8;
                    jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(productoTest);
                    Console.WriteLine("Changing Marca Values from Id " + productoTest.Id);
                    response = await HttpClient.PutAsync($"https://localhost:5000/api/Productos/{productoTest.Id}",
                            new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());
                    /////////////////////////////////////////////GET//////////////////////////////////////////////
                    Console.WriteLine("Testing GET method");
                    response = await HttpClient.GetAsync($"https://localhost:5000/api/Productos/{productoTest.Id}");
                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();
                    categoriaTest = Newtonsoft.Json.JsonConvert.DeserializeObject<Categoria>(responseBody);

                    Console.WriteLine($"Marca Test  Id={productoTest.Id}, Name={productoTest.Name}");
                    //////////////////////////////////////////////////DELETE//////////////////////////////////////////////////
                    Console.WriteLine("Testing DELETE method");
                    response = await HttpClient.DeleteAsync($"https://localhost:5000/api/Productos?id={productoTest.Id}");
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString() + "\nTEST Producto API Complete press any key");

                }
            }
        }

        public async Task TestSales()
        {
            using (var HttpClientHandler = new HttpClientHandler())
            {
                HttpClientHandler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) =>
                { return true; };
                using (var HttpClient = new HttpClient(HttpClientHandler))
                {
                    ///////////////////////////////////GETALL///////////////////////////////////////////////////
                    Console.WriteLine("Testing GetAll() Vendedores");
                    List<Vendedor> vendedores= new List<Vendedor>();
                    Vendedor vendedor = new Vendedor();
                    HttpResponseMessage response = await HttpClient.GetAsync($"https://localhost:49446/api/Vendedores");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    vendedores = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Vendedor>>(responseBody);
                    foreach (var item in vendedores)
                    {
                        Console.WriteLine($"Id={item.Id}, UserName={item.UserName}, Password={item.Password}");
                    }
                    ///////////////////////////////////////////////POST//////////////////////////////////////////////
                    Console.WriteLine("Testing POST Vendedores");
                    vendedor.Id = 50;
                    vendedor.UserName = "admongus";
                    vendedor.Password = "admin";
                    Console.WriteLine($"Data passing: Id={vendedor.Id}, UserName={vendedor.UserName}, Password={vendedor.Password}");
                    string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(vendedor);
                    response = await HttpClient.PostAsync("https://localhost:49446/api/Vendedores", 
                        new StringContent(jsonContent, Encoding.UTF8,"application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());
                    ////////////////////////////////////////////PUT///////////////////////////////////////////////////
                    Console.WriteLine("Testing PUT Vendedores");
                    vendedor.UserName = "admin";
                    Console.WriteLine($"Changing UserName to: {vendedor.UserName}");
                    jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(vendedor);
                    response = await HttpClient.PutAsync($"https://localhost:49446/api/Vendedores/{vendedor.Id}",
                      new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());
                    //////////////////////////////////////////GET////////////////////////////////////////////
                    Console.WriteLine("Testing GET Vendedores");
                    response = await HttpClient.GetAsync($"https://localhost:49446/api/Vendedores/{vendedor.Id}");
                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();
                    vendedor = Newtonsoft.Json.JsonConvert.DeserializeObject<Vendedor>(responseBody);
                    Console.WriteLine($"New Info: Id={vendedor.Id}, UserName={vendedor.UserName}, Password={vendedor.Password}");
                    /////////////////////////////////////////DELETE////////////////////////////////////////////
                    Console.WriteLine("Testing DELETE Vendedores");
                    response = await HttpClient.DeleteAsync($"https://localhost:49446/api/Vendedores?id={vendedor.Id}");
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString() + "\nEnd of Vendedor API press any key");
                    Console.ReadKey();
                    /////////////////////////////////////////GETALL////////////////////////////////////////////
                    List<VentaProducto> ventasTest = new List<VentaProducto>();
                    VentaProducto ventaTest = new VentaProducto();
                    Console.WriteLine("Testing GETALL VentaProducto");
                    response = await HttpClient.GetAsync($"https://localhost:49446/api/Ventas");
                    response.EnsureSuccessStatusCode();
                    responseBody= await response.Content.ReadAsStringAsync();
                    ventasTest = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VentaProducto>>(responseBody);
                    foreach (var item in ventasTest)
                    {
                        Console.WriteLine($"Id={item.Id}, VendedorId={item.VendedorId},ProductoId={item.ProductoId}");
                    }
                    ///////////////////////////////////////////POST///////////////////////////////////////////////
                    Console.WriteLine("Testing POST VentaProducto");
                    ventaTest.Id = 50;
                    ventaTest.VendedorId = 2;
                    ventaTest.ProductoId= 2;
                    Console.WriteLine($"Insert data: Id={ventaTest.Id}, vendedorId={ventaTest.VendedorId}, productoId={ventaTest.ProductoId}");
                    jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(ventaTest);
                    response = await HttpClient.PostAsync("https://localhost:49446/api/Ventas",
                        new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());
                    //////////////////////////////////////////PUT///////////////////////////////////////////////
                    Console.WriteLine("Testing PUT VentaProducto");
                    ventaTest.ProductoId= 6;
                    Console.WriteLine($"New productId={ventaTest.ProductoId}");
                    jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(ventaTest);
                    response = await HttpClient.PutAsync($"https://localhost:49446/api/Ventas/{ventaTest.Id}",
                        new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString());
                    //////////////////////////////////////////GET/////////////////////////////////////////////
                    Console.WriteLine("Testing GET VentaProducto");
                    response = await HttpClient.GetAsync($"https://localhost:49446/api/Ventas/{ventaTest.Id}");
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                    ventaTest = Newtonsoft.Json.JsonConvert.DeserializeObject<VentaProducto>(responseBody);
                    Console.WriteLine($"Id={ventaTest.Id}, vendedorId={ventaTest.VendedorId}, productId={ventaTest.ProductoId}");
                    ////////////////////////////////////////DELETE//////////////////////////////////////////////
                    Console.WriteLine("Testing DELETE VentaProducto");
                    response = await HttpClient.DeleteAsync($"https://localhost:49446/api/Ventas?id={ventaTest.Id}");
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.StatusCode.ToString() + "\nEnd of Ventas API");
                    Console.ReadKey();
                }
            } 
        }
    }
}
