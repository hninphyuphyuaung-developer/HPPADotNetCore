using HPPADotNetCore.ConsoleApp.Models;
using System.Collections.Generic;

namespace HPPADotNetCore.ConsoleApp.Models
{
    public class FamilyListResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<FamilyDataModel> Data { get; set; }
    }
}
