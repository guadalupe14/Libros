using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Data
{
    public class LibroManager
    {
        const string url = "http://192.168.1.93:3000/libros/";
        public async Task<IEnumerable<Libro>>GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Libro>>(result);
        }
        public async Task<Libro> Add(string titulo, string genero, string autor)
        {
            Libro libro = new Libro()
            {
                Titulo = titulo,
                Genero = genero,
                Autor = autor
            };
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(libro), 
                    Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Libro>(
                await response.Content.ReadAsStringAsync());
        }

    }
}
