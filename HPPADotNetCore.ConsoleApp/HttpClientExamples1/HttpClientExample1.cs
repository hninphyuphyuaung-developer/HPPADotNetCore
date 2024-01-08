using HPPADotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HPPADotNetCore.ConsoleApp.HttpClientExamples1
{
    public class HttpClientExample1
    {
        public async Task Run()
        {
            await Read();
            //await Edit(1018);
            //await Create("test1", "test2", "test3");
            await Update(1003, "test1", "test2", "test3");
            //await Delete(1001);
        }

        public async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7122/api/family");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<FamilyDataModel> lst = JsonConvert.DeserializeObject<List<FamilyDataModel>>(jsonStr);
                foreach (FamilyDataModel item in lst)
                {
                    Console.WriteLine(item.FamilyId);
                    Console.WriteLine(item.ParentName);
                    Console.WriteLine(item.SonName);
                    Console.WriteLine(item.DaughterName);
                    Console.WriteLine("_________");
                }
            }
        }

        public async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7122/api/family/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                var item = model.Data;
                    Console.WriteLine(item.FamilyId);
                    Console.WriteLine(item.ParentName);
                    Console.WriteLine(item.SonName);
                    Console.WriteLine(item.DaughterName);
                    Console.WriteLine("_________");
            }
            else
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }

        public async Task Create(string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            var jsonFamily = JsonConvert.SerializeObject(family);
            HttpContent httpContent = new StringContent(jsonFamily, Encoding.UTF8, Application.Json);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("https://localhost:7122/api/family", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }

        public async Task Update(int id, string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            var jsonFamily = JsonConvert.SerializeObject(family);
            HttpContent httpContent = new StringContent(jsonFamily, Encoding.UTF8, Application.Json);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync($"https://localhost:7122/api/family/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
            else
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }

        public async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7122/api/family/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }
    }
}
