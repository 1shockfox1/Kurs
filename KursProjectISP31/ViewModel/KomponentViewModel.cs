using KursProjectISP31.Model;
using KursProjectISP31.Services;
using KursProjectISP31.Utills;
using KursProjectISP31.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursProjectISP31.ViewModel
{
   public class KomponentViewModel:ViewModelBase
    {

        private ObservableCollection<Komponent> komponents;
        public ObservableCollection<Komponent> Komponents
        {
            get { return komponents; }
            set
            {
                if (komponents != value)
                {
                    komponents = value;
                    OnPropertyChanged(nameof(Komponents));
                }
            }
        }
        public KomponentService komponentService;
        
        private Komponent selectedKomponent;

        public Komponent SelectedKomponent
        {
            get { return selectedKomponent; }

            set
            {
                selectedKomponent = value;
                OnPropertyChanged(nameof(SelectedKomponent));
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
        public KomponentViewModel()
        {
            komponentService = new KomponentService();
            Komponents = new ObservableCollection<Komponent>(komponentService.GetAll());
        }

       

        private RelayCommand? addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                {
                    KomponentWindow window = new KomponentWindow(new Komponent());
                    if (window.ShowDialog() == true)
                    {
                        komponentService.Add(window.Komponent);
                      Komponents.Add(window.Komponent);
                        
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
                        Komponent komponent = o as Komponent;
                        KomponentWindow window = new KomponentWindow(komponent);
                        if (window.ShowDialog() == true)
                        {
                            komponentService.Update(window.Komponent);
                           
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
                        Komponent komponent = (o as Komponent)!;
                       MessageBoxResult result =  MessageBox.Show("Вы действительно хотите удалить?"+ komponent.Idkomp!,
                            "Удаление обьекта", MessageBoxButton.YesNo,MessageBoxImage.Warning);

                        if(result == MessageBoxResult.Yes)
                        {
                            komponentService.Delete(komponent);
                            Komponents.Remove(komponent);
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
                         Komponents = new ObservableCollection<Komponent>(komponentService.GetAll());
                      }
                      else
                      {
                          Komponents = new ObservableCollection<Komponent>(komponentService.Search(SearchText));
                      }
                  }));
            }
        }
    }
}
