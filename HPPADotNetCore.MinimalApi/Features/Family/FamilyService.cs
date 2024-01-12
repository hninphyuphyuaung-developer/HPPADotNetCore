using HPPADotNetCore.MinimalApi.EFDbContext;
using HPPADotNetCore.MinimalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPPADotNetCore.MinimalApi.Features.Family
{
	public static class FamilyService
	{
		public static void AddFamilyService(this IEndpointRouteBuilder app)
		{
			app.MapGet("/family/{pageNo}/{pageSize}", async ([FromServices] AppDbContext db, int pageNo, int pageSize) =>
			{
				return await db.Families
				.AsNoTracking()
				.Skip((pageNo - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
			})
			.WithName("GetFamilies")
			.WithOpenApi();

			app.MapPost("/family", async ([FromServices] AppDbContext db, FamilyDataModel family) =>
			{
				await db.Families.AddAsync(family);
				var result = await db.SaveChangesAsync();

				string message = result > 0 ? "Saving Successful." : "Saving Failed.";
				return Results.Ok(new FamilyResponseModel 
				{
					Data = family, 
					IsSuccess = result > 0, 
					Message = message 
				});
			})
			.WithName("CreateFamily")
			.WithOpenApi();

			app.MapPut("/family", async ([FromServices] AppDbContext db, int id, FamilyDataModel family) =>
			{
				var item = await db.Families.FirstOrDefaultAsync(x => x.FamilyId == id);

				item.ParentName = family.ParentName;
				item.SonName = family.SonName;
				item.DaughterName = family.DaughterName;
				var result = await db.SaveChangesAsync();

				string message = result > 0 ? "Updating Successful." : "Updating Failed.";
				return Results.Ok(new FamilyResponseModel
				{
					Data = family,
					IsSuccess = result > 0,
					Message = message
				});
			})
			.WithName("UpdateFamily")
			.WithOpenApi();

			app.MapDelete("/family", async ([FromServices] AppDbContext db,int id) =>
			{
				var item = await db.Families.FirstOrDefaultAsync(x => x.FamilyId == id);
				db.Families.Remove(item);
				var result = await db.SaveChangesAsync();

				string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
				return Results.Ok(new FamilyResponseModel
				{
					IsSuccess = result > 0,
					Message = message
				});
			})
			.WithName("DeleteFamily")
			.WithOpenApi();
		}
	}
}