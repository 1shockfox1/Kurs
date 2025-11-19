using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace KursProjectISP31.Model;

public partial class Sumzakaz
{
    private string datazakaza;
    
    public string Datazakaza
    {
        get { return datazakaza; }
        set
        {
            datazakaza = value;
            OnPropertyChanged(nameof(Datazakaza));
        }
    }


    private string client;
    public string Client
    {
        get { return client; }

        set
        {
            client = value; 
            OnPropertyChanged(nameof(Client));
        }
    }


    private int tovar;
    public int Tovar
    {
        get { return tovar; }
        set
        {
            tovar = value;
            OnPropertyChanged(nameof(Tovar));
        }
    }


    private int kolvo;
    public int Kolvo

    {
        get { return kolvo; }
        set
        {
            kolvo = value;
            OnPropertyChanged(nameof(Kolvo));
        }
    }

    private int cina;
    public int Cina
    {
        get { return cina; }
        set
        {
            cina = value;
            OnPropertyChanged(nameof(Cina));
        }
    }


    private string status;
    public string Status
    {
        get { return status; }

        set
        {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }


    private int idzakaza;
    public int Idzakaza
    {
        get { return idzakaza; }
        set
        {
            idzakaza = value;
            OnPropertyChanged(nameof(Idzakaza));
        }
    }


    public Sumzakaz(string datazakaz, string client, int tovar, int kolvo, int cina, string status, int idzakaza)
    {
        this.Datazakaza = datazakaz;
        this.Client = client;
        this.Tovar = tovar;
        this.Kolvo = kolvo;
        this.Cina = cina;
        this.Status = status;
        this.Idzakaza = idzakaza;
    }

    public Sumzakaz()
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
                case "Datazakaz":
                    if( Datazakaza != null )
                    {
                        if (!Regex.IsMatch(Datazakaza!, @"[0-9]+$"))
                            error = "Дата не должна содержать букв";
                    }
                    break;

                case "Client":
                    if (Client != null)
                    {
                        if (!Regex.IsMatch(Client!, @"[A-Za-z0-9]+$"))
                            error = "Рег.номер не должен содержать вспомогательных символов";
                    }
                    break;

                case "Tovar":
                    if (Tovar <= 0)
                        error = " Товара не может быть отрицательный";
                   break;

                case "Kolvo":
                    if (Kolvo < 0)
                        error = "необходимое кол-во не может быть меньше нуля";
                    break;
                case "Cina":
                    if (Cina < 0)
                        error = "Цена не может быть отрицательной";
                    break;
                case "Status": 
                    if(Status != null)
                        if(!Regex.IsMatch(Datazakaza!, @"[Оплачен-неоплачен]+$"))
                            error = "Статус может быть только или ОПЛАЧЕН или НЕОПЛАЧЕН";
                    break;
                case "Idzakaza":

                    if (Idzakaza < 0)
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
        return Datazakaza + " " + Client + " " + Tovar + " " + Kolvo + " " + Cina + " " + Status+ " " + Idzakaza;
    }

     public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}

