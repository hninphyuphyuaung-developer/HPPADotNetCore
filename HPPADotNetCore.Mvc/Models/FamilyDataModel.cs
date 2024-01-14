using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.MvcApp.Models
{
    [Table("Tbl_Family")]
    public class FamilyDataModel
    {
        [Key]
        [Column("FamilyId")]
        public int FamilyId { get; set; }

        [Column("ParentName")]
        public string? ParentName { get; set;}

        [Column("SonName")]
        public string? SonName { get; set;}

        [Column("DaughterName")]
        public string? DaughterName { get; set;}
    }

	public class FamilyResponseModel
	{
		public bool IsSuccess { get; set; }

		public string Message { get; set; }

		public FamilyDataModel Data { get; set; }
	}

    public class FamilyListResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<FamilyDataModel> Data { get; set; }
    }

    public class FamilyDataResponseModel
    {
        public PageSettingModel pageSetting { get; set; }
        public List<FamilyDataModel> Families { get; set; }
    }

    public class PageSettingModel
    {
        public PageSettingModel()
        {
        }

        public PageSettingModel(int pageNo ,int pageSize ,int pageCount)
        {
            PageNo = pageNo;
            PageSize = pageSize;
            PageCount = pageCount;
        }

        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}
