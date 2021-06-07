using System;
using System.Drawing;
using System.Windows.Forms;


namespace SteganographyJPEG
{
    public partial class Form2 : Form
    {
        private readonly Form1 _mainForm;

        public Form2(Form1 mainForm)
        {
            this._mainForm = mainForm;
            InitializeComponent();
        }

        private void buttonСalculate_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticalCharacteristics statParams = new StatisticalCharacteristics();
                SteganoContainer container = new SteganoContainer(_mainForm.ContainerForDecode);
                SteganoContainer original = new SteganoContainer(_mainForm.ContainerForEncode);
                
                Color maxDifference = statParams.getMaxDifference(container, original);
                string maxDifferenceAlpha = Convert.ToString(maxDifference.A, 2).PadLeft(8,'0');
                string maxDifferenceRed = Convert.ToString(maxDifference.R, 2).PadLeft(8,'0');
                string maxDifferenceGreen = Convert.ToString(maxDifference.G, 2).PadLeft(8,'0');
                string maxDifferenceBlue = Convert.ToString(maxDifference.B, 2).PadLeft(8,'0');
                textBoxMaxDifference.Text = "Alpha: " + maxDifferenceAlpha + " Red: " + maxDifferenceRed + " Green: " + maxDifferenceGreen + " Blue: " + maxDifferenceBlue;
                
                
                double [] pValues = new double [300];

                for (double i = 0; i < 300; i++)
                {
                    pValues[(int)i] = i;
                }

                var psnrValues = statParams.getPSNRValues(_mainForm.ContainerForEncode, _mainForm.InputMessage, pValues.Length, 
                    _mainForm.EncodeKey);

                for (int i = 0; i < 300; i++)
                {
                    if (double.IsInfinity(psnrValues[i]))
                    {
                        psnrValues[i] = 0;
                    }
                }

                this.chartPSNRfromP.Series[0].Points.Clear();
                
                for (int i = 0; i < pValues.Length; i++)
                {
                    this.chartPSNRfromP.Series[0].Points.AddXY(pValues[i],psnrValues[i]);
                }

            }
            catch (Exception excptn)
            {
                MessageBox.Show("Анта бака!\nОшибка при расчете характеристик!\n" + excptn.Message + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}