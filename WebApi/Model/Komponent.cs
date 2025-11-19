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
    private int? idkomp;
    public int? Idkomp
    {
        get { return idkomp; }
        set
        {
            idkomp = value;
            OnPropertyChanged(nameof(Idkomp));
        }
    }

    private string? namekomp;
    public string? Namekomp
    {
        get { return namekomp; }
        set
        {
            namekomp = value;
            OnPropertyChanged(nameof(Namekomp));
        }
    }


    private int? neobxodimo;
    public int? Neobxodimo
    {
        get { return neobxodimo; }

        set
        {
            neobxodimo = value;
            OnPropertyChanged(nameof(Neobxodimo));
        }
    }



    private int? kolvonasclabe;
    public int? Kolvonasclade

    {
        get { return kolvonasclabe; }

        set
        {
            kolvonasclabe = value;
            OnPropertyChanged();
        }
    }


    public Komponent(int? idkomp,  string? namekomp,  int? neobxodimo,  int? kolvonasclabe,  ICollection<Zakaznakomp> zakaznakomps)
    {
        this.Idkomp = idkomp;
        
        this.Namekomp = namekomp;
       
        this.Neobxodimo = neobxodimo;
        
        this.kolvonasclabe = kolvonasclabe;
        
        this.Zakaznakomps = zakaznakomps;
    }

    public Komponent()
    {

    }
    public string Error => throw new NotImplementedException();
    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "Idkomp":

                    if (Idkomp < 0)
                    {
                            error = "айди не может быть равным нулю";
                    }
                    break;

                case "Namekomp":
                    if (Namekomp != null)
                    {
                        if (!Regex.IsMatch(Namekomp!,@"[A-Za-z0-9]+$"))
                            error = "Рег.номер не должен содержать вспомогательных символов";
                        }
                    else
                    {
                        error = "Имя не должно быть пустым";
                    }
                    break;
                case "Neobxodimo":

                    if (Neobxodimo < 0)
                    {
                        error = "айди не может быть равным нулю";
                    }
                    break;

                case "Kolvonasclabe":

                    if (Kolvonasclade < 0)
                    {
                        error = "айди не может быть равным нулю";
                    }
                    break;


            }
            return error;
        }
    }

    public override string ToString()
    {
        return Idkomp+" " + Namekomp+ " " + Neobxodimo+" " + Kolvonasclade;
    }
    public virtual ICollection<Zakaznakomp> Zakaznakomps { get; set; } = new List<Zakaznakomp>();
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
