using KursClientChoco.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using KursClientChoco.Model;
using KursClientChoco.Services;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using KursClientChoco.View;
using System.Runtime.CompilerServices;

namespace KursClientChoco.ViewModels
{
    class SumzakazViewModels : ViewModelBase
    {
        private SumzakazService sumzakazService;
        private ObservableCollection<Sumzakaz> sumzakazsList;
        public ObservableCollection<Sumzakaz> SumzakazsList
        {
            get { return sumzakazsList; }

            set
            {
                sumzakazsList = value;
                OnPropertyChanged(nameof(SumzakazsList));
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

        public SumzakazViewModels()
        {
            sumzakazService = new SumzakazService();
            Load();
        }

        private void Load()
        {
            try
            {
                SumzakazsList = null!;
                Task<List<Sumzakaz>> task = Task.Run(() => sumzakazService.GetAll());
                SumzakazsList = new ObservableCollection<Sumzakaz>(task.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(async obj =>
                  {
                      try
                      {
                          SumzakazWindow window = new SumzakazWindow(new Sumzakaz());
                          if (window.ShowDialog() == true)
                          {
                              await sumzakazService.Add(window.Sumzakaz);
                              Load();
                          }
                      }
                      catch { }
                  }));
            }
        }
        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(async obj =>
                  {
                      Sumzakaz chitatel = (obj as Sumzakaz)!;
                      SumzakazWindow window = new SumzakazWindow(chitatel);
                      if (window.ShowDialog() == true)
                      {
                          await sumzakazService.Update(window.Sumzakaz);
                      }
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(async obj =>
                  {
                      Sumzakaz chitatel = (obj as Sumzakaz)!;
                      MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить объект " + chitatel!.Client, "Удаление объекта", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                      if (result == MessageBoxResult.Yes)
                      {
                          await sumzakazService.Delete(chitatel);
                          Load();
                      }
                  }));
            }
        }
    }
}