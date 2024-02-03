using itsEVEST.Model;
using System.Collections.ObjectModel;

namespace itsEVEST.ViewModels
{
    internal class DataInsertViewModel : BaseViewModel
    {
        public ObservableCollection<MatchData>? Inputs { get; set; }

        public DataInsertViewModel()
        {
            Inputs = new ObservableCollection<MatchData>();
            MatchData defaultItem = new MatchData();
            Inputs.Add(defaultItem);
            Query = defaultItem;
        }

        private MatchData query;
        public MatchData Query
        {
            get { return query; }
            set 
            {
                query = value;
                OnPropertyChanged();
            }
        }
        
    }
}
