using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.ConsoleApp.Models
{
    public class FamilyViewModel
    {
        public int Id { get; set; }

        public string? Parent { get; set; }

        public string? Son { get; set; }

        public string? Daughter { get; set; }
    }
}
