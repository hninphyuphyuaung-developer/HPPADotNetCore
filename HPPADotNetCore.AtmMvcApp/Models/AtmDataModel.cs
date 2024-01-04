using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPPADotNetCore.AtmMvcApp.Models
{
    [Table("Tbl_Atm1")]
    public class AtmDataModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("CardNumber")]
        public string CardNumber { get; set; }
        [Column("Pin")]
        public int Pin {  get; set; }
        [Column("Balance")]
        public int Balance { get; set; }
    }
    public class UserInfoModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
