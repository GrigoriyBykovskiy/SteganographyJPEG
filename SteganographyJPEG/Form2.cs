using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteganographyJPEG
{
    public partial class Form2 : Form
    {
        private readonly Form1 _mainForm;
        public StatisticalCharacteristics StatParams;
        public Form2(Form1 mainForm)
        {
            this._mainForm = mainForm;
            InitializeComponent();
        }

        private void buttonСalculate_Click(object sender, EventArgs e)
        {
            try
            {
                StatParams = new StatisticalCharacteristics();
                Color maxDifference = StatParams.getMaxDifference(_mainForm.ContainerForEncode, _mainForm.ContainerForDecode);
                string maxDifferenceAlpha = Convert.ToString(maxDifference.A, 2).PadLeft(8,'0');
                string maxDifferenceRed = Convert.ToString(maxDifference.R, 2).PadLeft(8,'0');
                string maxDifferenceGreen = Convert.ToString(maxDifference.G, 2).PadLeft(8,'0');
                string maxDifferenceBlue = Convert.ToString(maxDifference.B, 2).PadLeft(8,'0');
                textBoxMaxDifference.Text = "Alpha: " + maxDifferenceAlpha + " Red: " + maxDifferenceRed + " Green: " + maxDifferenceGreen + " Blue: " + maxDifferenceBlue;
            }
            catch (Exception excptn)
            {
                MessageBox.Show("Анта бака!\nОшибка при расчете характеристик!\n" + excptn.Message + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}