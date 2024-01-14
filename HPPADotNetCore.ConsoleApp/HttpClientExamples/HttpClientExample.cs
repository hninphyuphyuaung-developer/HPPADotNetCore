using HPPADotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HPPADotNetCore.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await Read();
            //await Edit(40);
            //await Delete(30);
            //await Create("name1", "name2", "name3");
            //await Updateput(30, "Tom", "Jack", "Mia");
            //await Updatepatch(37, null, null, "Dede");
        }

        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7122/api/FamilyAdoDotNet");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();

                // json to C# object => DeserializeObject
                // C# object to json => SerializeObject
                List<FamilyDataModel> lst = JsonConvert.DeserializeObject<List<FamilyDataModel>>(jsonStr);
                foreach(FamilyDataModel item in lst)
                {
                    Console.WriteLine(item.FamilyId);
                    Console.WriteLine(item.ParentName);
                    Console.WriteLine(item.SonName);
                    Console.WriteLine(item.DaughterName);
                    Console.WriteLine("------------------------");
                }
            }
        }

		private async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7122/api/FamilyAdoDotNet/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                if (model.IsSuccess)
                {
                    var item = model.Data;
                    Console.WriteLine(item.FamilyId);
                    Console.WriteLine(item.ParentName);
                    Console.WriteLine(item.SonName);
                    Console.WriteLine(item.DaughterName);
                    Console.WriteLine("------------------------");
                }
                else
                {
                    Console.WriteLine(model.Message);
                }
            }
            else
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }

		private async Task Create(string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            string jsonStrFamily = JsonConvert.SerializeObject(family);
            HttpContent httpContent = new StringContent(jsonStrFamily, Encoding.UTF8, Application.Json);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync($"https://localhost:7122/api/FamilyAdoDotNet", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.IsSuccess);
                Console.WriteLine(model.Message);
            }
        }

		private async Task Updateput(int id, string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            string jsonStrFamily = JsonConvert.SerializeObject(family);
            HttpContent httpContent = new StringContent(jsonStrFamily, Encoding.UTF8, Application.Json);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync($"https://localhost:7122/api/FamilyAdoDotNet/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.IsSuccess);
                Console.WriteLine(model.Message);
            }
            else
            {
                var jsonStr = await response.Content.ReadAsStringAsync();

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }

		private async Task Updatepatch(int id, string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            string jsonStrFamily = JsonConvert.SerializeObject(family);
            HttpContent httpContent = new StringContent(jsonStrFamily, Encoding.UTF8, Application.Json);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PatchAsync($"https://localhost:7122/api/FamilyAdoDotNet/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.IsSuccess);
                Console.WriteLine(model.Message);
            }
        }

		private async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7122/api/FamilyAdoDotNet/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);

                Console.WriteLine(model.IsSuccess);
                Console.WriteLine(model.Message);
            }
            else
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }
    }
}
