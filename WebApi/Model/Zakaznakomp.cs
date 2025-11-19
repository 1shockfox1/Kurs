using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace KursProjectISP31.Model;

public partial class Zakaznakomp
{


    private int idzakazanapost;
    public int Idzakazanapost
    {
        get { return idzakazanapost; }
        set
        {
            idzakazanapost = value;
            OnPropertyChanged(nameof(Idzakazanapost));
        }
    }

    private int idkomp;
    public int Idkomp
    {
        get { return idkomp; }
        set
        {
            idkomp = value;
            OnPropertyChanged(nameof(Idkomp));
        }
    }

    private string post;
    public string Post
    {
        get { return post; }
        set
        {
            post = value;
            OnPropertyChanged(nameof(Post));
        }
    }

    private int cinazatovar;
    public int Cinazatovar
    {
        get { return  cinazatovar; }
        set
        {
            cinazatovar = value;
            OnPropertyChanged(nameof(Cinazatovar));
        }
    }


    private string statuspost;
    public string Statyspost
    {
        get { return statuspost; }
        set
        {
            statuspost = value;
            OnPropertyChanged(nameof(Statyspost));
        }
    }


    public Zakaznakomp(int idzakazanapost,  int idkomp,  string post,  int cinazatovar,  string statuspost)
    {
        Idzakazanapost = idzakazanapost;   
        Idkomp = idkomp;    
        Post = post;
        Cinazatovar = cinazatovar;
        this.statuspost = statuspost;
        
    }

    public Zakaznakomp()
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
                case "Idzakazanapost":
                    if (Idzakazanapost < 0)
                    {
                        error = "айди не может быть равным нулю";
                    }
                    break;

                case "Idkomp":
                    if (Idkomp < 0)
                    {
                        error = "айди не может быть равным нулю";
                    }

                    break;

                case "Post":
                    if (Post != null)
                    {
                        if (!Regex.IsMatch(Post!, @"[A-Za-z0-9]+$"))
                            error = "---";
                    }
                    break;
                case "Cinazatovar":
                    if (Cinazatovar < 0)
                    {
                        error = "---";
                    }
                        break;
                case "Statuspost":
                    if (Statyspost!= null)
                    {
                        if (!Regex.IsMatch(Statyspost!, @"[A-Za-z0-9]+$"))
                            error = "---";
                    }
                    break;   



            }
            return error;
        }
    }


    public override string ToString()
    {
        return Idzakazanapost + " " + Idkomp + " " + Post + " " + Cinazatovar + " " + Statyspost;
    }
    public virtual Komponent IdkompNavigation { get; set; } = null!;



    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
