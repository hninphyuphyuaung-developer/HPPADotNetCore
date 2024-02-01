using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPPADotNetCore.AtmWebApp.Models
{
    [Table("Tbl_User")]
    public class RegisterModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Password")]
        public string? Password { get; set; }
    }

    public class AtmResponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public RegisterModel Data { get; set; }
    }
}
