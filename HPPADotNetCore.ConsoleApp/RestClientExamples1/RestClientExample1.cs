using HPPADotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HPPADotNetCore.ConsoleApp.RestClientExamples1
{
	public class RestClientExample1
    {
        public async Task Run()
        {
            await Read();
            //await Edit(1048);
            //await Create("test1", "test2", "test3");
            //await Update(2047, "U Ba", "Mg Mg", "Aye");
            //await Delete(2047);
        }

        private async Task Read()
        {
            RestRequest request = new RestRequest("https://localhost:7122/api/family", Method.Get);
            RestClient client = new RestClient();
            //var response = await client.GetAsync(request);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
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

		private async Task Edit(int id)
        {
			RestRequest request = new RestRequest($"https://localhost:7122/api/family/{id}", Method.Get);
			RestClient client = new RestClient();
			var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                var item = model!.Data;
                    Console.WriteLine(item.FamilyId);
                    Console.WriteLine(item.ParentName);
                    Console.WriteLine(item.SonName);
                    Console.WriteLine(item.DaughterName);
                    Console.WriteLine("_________");
            }
            else
            {
                string jsonStr = response.Content!;
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model!.Message);
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
			RestRequest request = new RestRequest("https://localhost:7122/api/family", Method.Post);
            request.AddJsonBody(family);
			RestClient client = new RestClient();
			var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model!.Message);
            }
        }

		private async Task Update(int id, string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
			RestRequest request = new RestRequest($"https://localhost:7122/api/family/{id}", Method.Put);
            request.AddJsonBody(family);
			RestClient client = new RestClient();
			var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model!.Message);
            }
            //else
            //{
            //    string jsonStr = response.Content!;
            //    var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
            //    Console.WriteLine(model!.Message);
            //}
        }

		private async Task Delete(int id)
		{
			RestRequest request = new RestRequest($"https://localhost:7122/api/family/{id}", Method.Delete);
			RestClient client = new RestClient();
			var response = await client.ExecuteAsync(request);
			if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var model = JsonConvert.DeserializeObject<FamilyResponseModel>(jsonStr);
                Console.WriteLine(model!.Message);
            }
		}
	}
}
