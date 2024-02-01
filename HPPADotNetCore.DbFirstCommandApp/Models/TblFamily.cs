using System;
using System.Collections.Generic;

namespace HPPADotNetCore.DbFirstCommandApp.Models;

public partial class TblFamily
{
    public int FamilyId { get; set; }

    public string ParentName { get; set; } = null!;

    public string SonName { get; set; } = null!;

    public string DaughterName { get; set; } = null!;
}
