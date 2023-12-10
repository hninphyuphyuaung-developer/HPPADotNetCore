namespace HPPADotNetCore2.MvcApp.Models
{
    public class FamilyListResponseModel
    {
        public List<FamilyDataModel> FamilyList { get; set; }

        public int PageNo { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int PageRowCount { get; set; }

    }
}
