using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace KursProjectISP31.Model;

public partial class Komponent
{
    public int? Idkomp {  get; set; }
    
    public string? Namekomp { get; set; }

    public int? Neobxodimo  { get; set; }

    public int? Kolvonasclade { get; set; }

}
