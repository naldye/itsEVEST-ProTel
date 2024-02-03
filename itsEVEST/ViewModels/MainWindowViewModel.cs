using itsEVEST.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsEVEST.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<MatchData>? MatchData { get; set; }

        /*public string MatchInfo 
        {
            get {  return MatchInfo; }
            set 
            { 
                MatchInfo = Data.Phase + Data.Class + Data.Gender + Data.Weight;
                OnPropertyChanged();
            }

        }*/

        public MainWindowViewModel() => MatchData = new ObservableCollection<MatchData>();

        private MatchData data;

        public MatchData Data
        {
            get { return data; }
            set 
            { 
                data = value;
                OnPropertyChanged();
            }
        }


    }
}
