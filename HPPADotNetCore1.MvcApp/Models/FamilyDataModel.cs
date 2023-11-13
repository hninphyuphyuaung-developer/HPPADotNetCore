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
}
