using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace itsEVEST.View.UserControls
{
    public partial class ControlBar : UserControl
    {
        
        public ControlBar()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataInsertView dataInsertView = new DataInsertView(App.Current.MainWindow);
            dataInsertView.ShowDialog();
        }
        
    }
}
