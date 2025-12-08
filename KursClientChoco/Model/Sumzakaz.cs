using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace KursClientChoco.Model;

public partial class Sumzakaz
{  

    public string Datazakaza {  get; set; }
   
    public string Client {  get; set; }
    
    public string Tovar {  get; set; }
    
    public int Kolvo { get; set; }

    public int Cina { get; set; }
  
    public string Status { get; set; }
    
    public int Idzakaza { get; set; }
    
}
   

