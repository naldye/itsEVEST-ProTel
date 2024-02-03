using itsEVEST.View.UserControls;
using itsEVEST.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace itsEVEST
{

    public partial class DataInsertView : Window 
    {
        public static DataInsertView Instance;
        public TextBox TBoxRedName;
        public DataInsertView(Window parentWindow) 
        {
            Owner = parentWindow;
            InitializeComponent();
            Instance = this;
            TBoxRedName = inputRedName;

            DataInsertViewModel vm = new DataInsertViewModel();
            DataContext = vm;

            inputRedName.Text = MainWindow.Instance.tbRedName.Text;
            inputRedTeam.Text = MainWindow.Instance.tbRedTeam.Text;
            inputBlueName.Text = MainWindow.Instance.tbBlueName.Text;
            inputBlueTeam.Text = MainWindow.Instance.tbBlueTeam.Text;

            inputClass.Text = MainWindow.Instance.matchClass;
            inputGender.Text = MainWindow.Instance.matchGender;
            inputWeight.Text = MainWindow.Instance.matchWeight;
            inputPhase.Text = MainWindow.Instance.matchPhase;

        }


        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.tbRedName.Text = inputRedName.Text;
            MainWindow.Instance.tbRedTeam.Text = inputRedTeam.Text;
            MainWindow.Instance.tbBlueName.Text = inputBlueName.Text;
            MainWindow.Instance.tbBlueTeam.Text = inputBlueTeam.Text;

            MainWindow.Instance.MatchInfo.Text = inputPhase.Text + " " + inputClass.Text + " " + inputWeight.Text + " " + inputGender.Text;

            MainWindow.Instance.matchClass = inputClass.Text;
            MainWindow.Instance.matchGender = inputGender.Text;
            MainWindow.Instance.matchWeight = inputWeight.Text;
            MainWindow.Instance.matchPhase = inputPhase.Text;
            updateAllSources();
            Close();
        }

        private void updateSourceForTextBox(TextBox textBox)
        {
            BindingExpression bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpression?.UpdateSource();
        }

        private void updateAllSources()
        {
            updateSourceForTextBox(inputRedName);
            updateSourceForTextBox(inputRedTeam);
            updateSourceForTextBox(inputBlueName);
            updateSourceForTextBox(inputBlueTeam);

            updateSourceForTextBox(inputClass);
            updateSourceForTextBox(inputGender);
            updateSourceForTextBox(inputWeight);
            updateSourceForTextBox(inputPhase);
        }

    }
}
