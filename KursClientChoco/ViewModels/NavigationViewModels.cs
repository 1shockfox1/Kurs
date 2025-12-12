using KursClientChoco.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursClientChoco.ViewModels
{
    public class NavigationViewModels : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand SumzakazCommand { get; set; }
        public void Home(object obj) => CurrentView = new HomeViewModels();
        public void Sumzakaz(object obj) => CurrentView = new SumzakazViewModels();
        public NavigationViewModels()
        {
            HomeCommand = new RelayCommand(Home);
            SumzakazCommand = new RelayCommand(Sumzakaz);
            CurrentView = new HomeViewModels();
        }
    }
}
