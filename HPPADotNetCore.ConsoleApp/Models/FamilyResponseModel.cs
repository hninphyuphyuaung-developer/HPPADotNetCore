namespace HPPADotNetCore.ConsoleApp.Models
{
    public class FamilyResponseModel
        {
            public bool IsSuccess { get; set; }

            public string Message { get; set; }

            public FamilyDataModel Data { get; set; }
        }
}
