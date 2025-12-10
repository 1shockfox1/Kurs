using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace KursClientChoco.Model;

public partial class Sumzakaz
{

    public string Datazakaza { get; set; } = null!;
   
    public string Client {  get; set; } = null!;

    public string Tovar {  get; set; } = null!;

    public int Kolvo { get; set; }

    public int Cina { get; set; }
  
    public string Status { get; set; } = null!;

    public int Idzakaza { get; set; }
    
}
   

