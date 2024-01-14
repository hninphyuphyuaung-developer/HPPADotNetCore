using HPPADotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using Refit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.ConsoleApp.RefitExamples1
{
	public class RefitExamples1
	{
		private readonly IFamilyApi familyApi = RestService.For<IFamilyApi>("https://localhost:7122");

		public async Task Run()
		{
			await Read();
			//await Edit(1048);
			//await Create("test1", "test2", "test3");
			//await Update(3047, "U Ba", "Mg Mg", "Aye");
			//await Delete(3048);
		}
		private async Task Read()
		{
			var model = await familyApi.GetFamilies();
			foreach (var item in model)
			{
				Console.WriteLine(item.FamilyId);
				Console.WriteLine(item.ParentName);
				Console.WriteLine(item.SonName);
				Console.WriteLine(item.DaughterName);
				Console.WriteLine("_________");
			}
		}
		private async Task Edit(int id)
		{
			var model = await familyApi.GetFamily(id);
			var item = model!.Data;
				Console.WriteLine(item.FamilyId);
				Console.WriteLine(item.ParentName);
				Console.WriteLine(item.SonName);
				Console.WriteLine(item.DaughterName);
				Console.WriteLine("_________");
		}
		private async Task Create(string parent, string son, string daughter)
		{
			FamilyDataModel family = new FamilyDataModel
			{
				ParentName = parent,
				SonName = son,
				DaughterName = daughter
			};
			var model = await familyApi.CreateFamily(family);
			Console.WriteLine(model!.Message);
		}

		private async Task Update(int id, string parent, string son, string daughter)
		{
			FamilyDataModel family = new FamilyDataModel
			{
				ParentName = parent,
				SonName = son,
				DaughterName = daughter
			};
			var model = await familyApi.UpdateFamily(id, family);
			Console.WriteLine(model!.Message);
		}

		private async Task Delete(int id)
		{
			var model = await familyApi.DeleteFamily(id);
			Console.WriteLine(model!.Message);
		}
	}
}
