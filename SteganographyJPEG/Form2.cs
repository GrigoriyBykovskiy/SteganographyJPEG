using System;
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
                MessageBox.Show("Анта бака!\nНо все хорошо!\n", "ОК", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception excptn)
            {
                MessageBox.Show("Анта бака!\nОшибка при расчете характеристик!\n" + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}