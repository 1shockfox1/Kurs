using KursClientChoco.Model;
using KursProjectISP31.Services;
using KursClientChoco.Utills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KursClientChoco.View;

namespace KursClientChoco.ViewModel
{
    class ZakaznakompViewModel: ViewModelBase
    {
        private ZakaznakompServices zakaznakompServices;

        private ObservableCollection<Zakaznakomp> zakaznakomps;
        public ObservableCollection<Zakaznakomp> Zakaznakomps
        {
            get { return zakaznakomps; }
            set
            {
                if (zakaznakomps != value)
                {
                    zakaznakomps = value;
                    OnPropertyChanged(nameof(Zakaznakomps));
                }
            }
        }
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        private Zakaznakomp selectedZakaznakomp;
        public Zakaznakomp SelectedZakaznakomp
        {
            get { return selectedZakaznakomp; }
            set
            {
                selectedZakaznakomp = value;
                OnPropertyChanged(nameof(SelectedZakaznakomp));
            }
        }

        public ZakaznakompViewModel()
        {
            zakaznakompServices = new ZakaznakompServices();
            Zakaznakomps = new ObservableCollection<Zakaznakomp>(zakaznakompServices.GetAll());
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      ZakaznakompWindow window = new ZakaznakompWindow(new Zakaznakomp());
                      if (window.ShowDialog() == true)
                      {
                          zakaznakompServices.Add(window.Zakaznakomp);
                          zakaznakomps.Add(window.Zakaznakomp);
                      }
                  }));
            }
        }
        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((o) =>
                  {
                      Zakaznakomp zakaznakomp = (o as Zakaznakomp)!;
                      ZakaznakompWindow window = new ZakaznakompWindow(zakaznakomp);
                      if (window.ShowDialog() == true)
                      {
                         zakaznakompServices.Update(window.Zakaznakomp);
                      }
                  }));
            }
        }
        private RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((o) =>
                  {
                      Zakaznakomp zakaznakomp = (o as Zakaznakomp)!;
                      MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить объект " + zakaznakomp!.Post + " " + zakaznakomp.Statyspost!.Substring(0, 1), "Удаление объекта", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                      if (result == MessageBoxResult.Yes)
                      {
                          zakaznakompServices.Delete(zakaznakomp);
                          zakaznakomps.Remove(zakaznakomp);
                      }
                  }));
            }
        }
        private RelayCommand? searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand((o) =>
                  {
                      if (String.IsNullOrEmpty(SearchText))
                      {
                          Zakaznakomps = new ObservableCollection<Zakaznakomp>(zakaznakompServices.GetAll());
                      }
                      else
                      {
                          Zakaznakomps = new ObservableCollection<Zakaznakomp>(zakaznakompServices.Search(SearchText));
                      }
                  }));
            }
        }
    }
}
