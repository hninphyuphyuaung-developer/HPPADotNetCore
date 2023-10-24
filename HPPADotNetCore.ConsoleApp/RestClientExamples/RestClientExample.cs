using HPPADotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HPPADotNetCore.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        public async Task Run()
        {
            await Read();
            //await Edit(35);
            await Delete(35);
            //await Create("u u", "mg mg", "ma ma");
            //await Updateput(41, "Tom", "Jack", "Mia");
            //await Updatepatch(37, "Micky", "Shady", null);
        }
        public async Task Read()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest("https://localhost:7122/api/FamilyAdoDotNet" , Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;

                List<FamilyDataModel> lst = JsonConvert.DeserializeObject<List<FamilyDataModel>>(jsonStr);
                foreach (FamilyDataModel item in lst)
                {
                    Console.WriteLine(item.FamilyId);
                    Console.WriteLine(item.ParentName);
                    Console.WriteLine(item.SonName);
                    Console.WriteLine(item.DaughterName);
                    Console.WriteLine("------------------------");
                }
            }
        }

        public async Task Edit(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7122/api/FamilyAdoDotNet/{id}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;

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
                var jsonStr = response.Content;
                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
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
            RestClient client = new RestClient();
            RestRequest request = new RestRequest("https://localhost:7122/api/FamilyAdoDotNet", Method.Post);
            request.AddBody(family);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.IsSuccess);
                Console.WriteLine(model.Message);
            }
        }

        public async Task Updateput(int id, string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7122/api/FamilyAdoDotNet/{id}", Method.Put);
            request.AddBody(family);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.IsSuccess);
                Console.WriteLine(model.Message);
            }
            else
            {
                var jsonStr = response.Content;

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }

        public async Task Updatepatch(int id, string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7122/api/FamilyAdoDotNet/{id}", Method.Patch);
            request.AddBody(family);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.IsSuccess);
                Console.WriteLine(model.Message);
            }
            else
            {
                var jsonStr = response.Content;

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }

        public async Task Delete(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7122/api/FamilyAdoDotNet/{id}", Method.Delete);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.IsSuccess);
                Console.WriteLine(model.Message);
            }
            else
            {
                var jsonStr = response.Content;

                FamilyResponseModel model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
        }
    }
}
