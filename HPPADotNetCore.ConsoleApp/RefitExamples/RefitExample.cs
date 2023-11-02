using HPPADotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly IFamilyApi familyApi;

        public RefitExample()
        {
            familyApi = RestService.For<IFamilyApi>("https://localhost:7122");
        }

        public async Task Run()
        {
            await Read();
            await Edit(44);
            //await Create("U Mg Mg", "Kyaw", "Lolli");
            //await Put(42, "U Ba", "Thura", "Aye Aye");
            //await Patch(44, "Tyron", null, null);
            //await Delete(43);
        }

        private async Task Read()
        {
            List<FamilyDataModel> lst = await familyApi.GetFamilies();
            Console.WriteLine(JsonConvert.SerializeObject(lst,Formatting.Indented));
        }

        private async Task Create(string parent, string son, string daughter)
        {
            FamilyResponseModel model = await familyApi.CreateFamily(new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            });
            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
        }

        private async Task Edit(int id)
        {
            FamilyResponseModel model = await familyApi.GetFamily(id);
            
            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
        }
        private async Task Put(int id, string parent, string son, string daughter)
        {
            FamilyResponseModel model = await familyApi.PutFamily(id,new FamilyDataModel()
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            });
            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
        }
        private async Task Patch(int id, string parent, string son, string daughter)
        {
            FamilyResponseModel model = await familyApi.PatchFamily(id, new FamilyDataModel()
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            });
            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
        }

        private async Task Delete(int id)
        {
            FamilyResponseModel model = await familyApi.DeleteFamily(id);

            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
        }
    }


    public interface IFamilyApi
    {
        [Get("/api/Family")]
        Task<List<FamilyDataModel>> GetFamilies();

        [Get("/api/Family/{pageNo}/{pageSize}")]
        Task<List<FamilyDataModel>> GetFamilies(int pageNo, int pageSize = 10);

        [Get("/api/Family/{id}")]
        Task<FamilyResponseModel> GetFamily(int id);

        [Post("/api/Family")]
        Task<FamilyResponseModel> CreateFamily(FamilyDataModel family);

        [Put("/api/Family/{id}")]
        Task<FamilyResponseModel> PutFamily(int id, FamilyDataModel family);

        [Patch("/api/Family/{id}")]
        Task<FamilyResponseModel> PatchFamily(int id, FamilyDataModel family);

        [Delete("/api/Family/{id}")]
        Task<FamilyResponseModel> DeleteFamily(int id);
    }
}
