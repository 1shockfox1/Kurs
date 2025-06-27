using KursProjectISP31.Model;
using KursProjectISP31.Utills;
using KursProjectISP31.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace KursProjectISP31.ViewModel
{
    public class NavigationViewModel:ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }

        public ICommand KomponentCommand { get; set; }

        public ICommand SumzakazCommand { get; set; }

        public ICommand ZakaznakompCommand {  get; set; }

        private void Home(object obj) => CurrentView = new HomeViewModel();
       
        private void Komponent(object obj) => CurrentView = new KomponentViewModel();

        private void Sumzakaz(object obj) => CurrentView = new SumzakazViewModel();

        private void Zakaznakomp(object obj) => CurrentView = new ZakaznakompViewModel();
      

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            KomponentCommand = new RelayCommand(Komponent);
            SumzakazCommand = new RelayCommand(Sumzakaz);
            ZakaznakompCommand = new RelayCommand(Zakaznakomp);
            // Startup Page
            CurrentView = new HomeViewModel();
        }
    }
}
