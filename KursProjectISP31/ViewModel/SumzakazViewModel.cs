using KursProjectISP31.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using KursProjectISP31.Model;
using KursProjectISP31.Services;
using KursProjectISP31.View;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace KursProjectISP31.ViewModel
{
    class SumzakazViewModel : ViewModelBase
    {
        private SumzakazService sumzakazService;


        private ObservableCollection<Sumzakaz> sumzakazs;
        public ObservableCollection<Sumzakaz> Sumzakazs
        {
            get { return sumzakazs; }

            set
            {
                sumzakazs = value;
                OnPropertyChanged(nameof(Sumzakaz));
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
        private Sumzakaz selectedSumzakaz;
        public Sumzakaz SelectedSumzakaz
        {
            get { return selectedSumzakaz; }
            set
            {
                selectedSumzakaz = value;
                OnPropertyChanged(nameof(SelectedSumzakaz));
            }
        }

        public SumzakazViewModel()
        {
            sumzakazService = new SumzakazService();
            Sumzakazs = new ObservableCollection<Sumzakaz>(sumzakazService.GetAll());
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      SumzakazWindow window = new SumzakazWindow(new Sumzakaz());
                      if (window.ShowDialog() == true)
                      {
                          sumzakazService.Add(window.Sumzakaz);
                          sumzakazs.Add(window.Sumzakaz);
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
                      Sumzakaz sumzakaz = (o as Sumzakaz)!;
                      SumzakazWindow window = new SumzakazWindow(sumzakaz);
                      if (window.ShowDialog() == true)
                      {
                          sumzakazService.Update(window.Sumzakaz);
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
                      Sumzakaz sumzakaz = (o as Sumzakaz)!;
                      MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить объект " + sumzakaz!.Datazakaza + " " + sumzakaz.Client!.Substring(0, 1) + "." +
                          sumzakaz.Status!.Substring(0, 1) + ".", "Удаление объекта", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                      if (result == MessageBoxResult.Yes)
                      {
                          sumzakazService.Delete(sumzakaz);
                          sumzakazs.Remove(sumzakaz);
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
                          Sumzakazs = new ObservableCollection<Sumzakaz>(sumzakazService.GetAll());
                      }
                      else
                      {
                          Sumzakazs = new ObservableCollection<Sumzakaz>(sumzakazService.Search(SearchText));
                      }
                  }));
            }
        }
    }
}