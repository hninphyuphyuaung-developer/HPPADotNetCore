using HPPADotNetCore.MinimalApi.Models;

namespace HPPADotNetCore.MinimalApi.Models
{
	public class FamilyResponseModel
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public FamilyDataModel Data { get; set; }
    }
}
