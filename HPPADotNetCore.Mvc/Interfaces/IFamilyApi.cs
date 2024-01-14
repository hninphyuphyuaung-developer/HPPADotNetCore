using HPPADotNetCore.MvcApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.MvcApp.RefitExamples1
{
	public interface IFamilyApi
	{
		[Get("/api/family")]
		Task<List<FamilyDataModel>> GetFamilies();

		[Get("/api/family/{id}")]
		Task<FamilyResponseModel> GetFamily(int id);

		[Post("/api/family")]
		Task<FamilyResponseModel> CreateFamily(FamilyDataModel family);

		[Put("/api/family/{id}")]
		Task<FamilyResponseModel> UpdateFamily(int id, FamilyDataModel family);

		[Delete("/api/family/{id}")]
		Task<FamilyResponseModel> DeleteFamily(int id);
	}
}
