using itsEVEST.View.UserControls;
using System.Windows;
using System.Windows.Controls;

namespace itsEVEST
{

    public partial class DataInsertView : Window
    {
        public bool AppliedPressed { get; set; }
        public string RedName { get; set; }
        public string RedTeam { get; set; }

        public string BLueName { get; set; }
        public string BLueTeam { get; set; }

        public string Class { get; set; }
        public string Gender { get; set; }
        public string Weight { get; set; }
        public string Phase { get; set; }


        public DataInsertView(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
        }

        private void DataInsert_Loaded(object sender, RoutedEventArgs e)
        {
            labeling();
        }


        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            AppliedPressed = true;
            RedName = inputRedName.tboxDataField.Text;
            RedTeam = inputRedTeam.tboxDataField.Text;

            BLueName = inputBlueName.tboxDataField.Text;
            BLueTeam = inputBlueTeam.tboxDataField.Text;

            Class = inputClass.tboxDataField.Text;
            Gender = inputGender.tboxDataField.Text;
            Weight = inputWeight.tboxDataField.Text;
            Phase = inputPhase.tboxDataField.Text;
            Close();
        }

        private void labeling()
        {
            inputRedName.tbFieldName.Text = "Nama";
            inputRedTeam.tbFieldName.Text = "Tim";

            inputBlueName.tbFieldName.Text = "Nama";
            inputBlueTeam.tbFieldName.Text = "Tim";

            inputClass.tbFieldName.Text = "Kelas";
            inputGender.tbFieldName.Text = "Gender";
            inputWeight.tbFieldName.Text = "Berat";
            inputPhase.tbFieldName.Text = "Fase";

        }

        
    }
}
