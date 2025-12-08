using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace   KursClientChoco.Model;

public partial class Zakaznakomp
{


    public int Idzakazanapost {  get; set; }

    public int Idkomp {  get; set; }
    
    public string Post {  get; set; }
    
    public int Cinazatovar {  get; set; }

    public string Statyspost {  get; set; }
    
}
