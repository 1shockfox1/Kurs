using KursClientChoco.Model;
using KursClientChoco.Utills;
using KursClientChoco.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace KursClientChoco.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand SumzakazCommand { get; set; }
        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void Sumzakaz(object obj) => CurrentView = new SumzakazViewModels();
        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            SumzakazCommand = new RelayCommand(Sumzakaz);
            CurrentView = new HomeViewModel();
        }
    }
}