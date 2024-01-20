using BlogDotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BlogDotNetCore.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            //await Read();
            // await Edit(20);
            // await Create("Test Title", "Test Author", "Test Content");
            //await  Update(26, " Title Test", "Test Author", "Test Content");
             await Delete(26);
        }

        public async Task Read()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7045");
            var response = await client.GetAsync("api/blog");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                List<BlogDataModel> lst = JsonConvert.DeserializeObject<List<BlogDataModel>>(jsonStr)!;
                // Console.WriteLine(lst);
                Console.WriteLine(JsonConvert.SerializeObject(lst, Formatting.Indented));
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
        }

        public async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7045");
            var response = await client.GetAsync($"api/blog/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr)!;
                // Console.WriteLine(lst);
                Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
        }

        public async Task Create(string title, string author, string content)
        {
            BlogDataModel blog = new BlogDataModel()
            {
                Blog_Author = author,
                Blog_Content = content,
                Blog_Title = title,
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7045");
            HttpResponseMessage response = await client.PostAsync($"api/blog", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }

        public async Task Update(int id, string title, string author, string content)
        {

            BlogDataModel blog = new BlogDataModel()
            {
                Blog_Author = author,
                Blog_Content = content,
                Blog_Title = title,
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7045");
            HttpResponseMessage response = await client.PutAsync($"api/blog/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }

        public async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7045");
            var response = await client.DeleteAsync($"api/blog/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
        }
    }
}
