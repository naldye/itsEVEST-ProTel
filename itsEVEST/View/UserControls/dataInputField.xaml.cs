using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace itsEVEST.View.UserControls
{
    /// <summary>
    /// Interaction logic for dataInputField.xaml
    /// </summary>
    public partial class dataInputField : UserControl
    {
        public dataInputField()
        {
            InitializeComponent();
        }

        private void tboxDataField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(tboxDataField.Text))
            {
                tbFieldPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                tbFieldPlaceholder.Visibility = Visibility.Hidden;
            }
        }
    }
}
