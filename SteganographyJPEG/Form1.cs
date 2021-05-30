using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteganographyJPEG
{
    public partial class Form1 : Form
    {
        public SteganoContainer ContainerForEncode;
        public SteganoContainer ContainerForDecode;
        public SteganoMessage InputMessage;
        public SteganoMessage OutputMessage;
        public SteganoTransformation Transformation;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void buttonGetMessage_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        InputMessage = new SteganoMessage(filePath);
                    }
                    catch (Exception excptn)
                    {
                        MessageBox.Show("Анта бака!\nОшибка при считывании файла-контейнера!\n" + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonGetEncodeContainer_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        ContainerForEncode = new SteganoContainer(filePath);
                    }
                    catch (Exception excptn)
                    {
                        MessageBox.Show("Анта бака!\nОшибка при считывании файла-контейнера!\n" + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonGetDecodeContainer_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "BMP files (*.bmp)|*.bmp|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        ContainerForDecode = new SteganoContainer(filePath);
                    }
                    catch (Exception excptn)
                    {
                        MessageBox.Show("Анта бака!\nОшибка при считывании файла-контейнера!\n" + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            try
            {
                Transformation = new SteganoTransformation();
                ContainerForEncode.InitBlocks(8, 8);
                ContainerForEncode.InitBlueComponent(8, 8);
                Transformation.Encode(ContainerForEncode, InputMessage, 2);
                ContainerForEncode.InsertBlueComponent(8, 8);
                ContainerForEncode.TestWriteImage(8, 8);
                //MessageBox.Show("Анта бака!\nНо все хорошо!\n" + ContainerForEncode.FilePath + InputMessage.FilePath, "ОК", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception excptn)
            {
                MessageBox.Show("Анта бака!\nОшибка при кодировании!\n" + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            try
            {
                Transformation = new SteganoTransformation();
                ContainerForDecode.InitBlocks(8, 8);
                ContainerForDecode.InitBlueComponent(8, 8);
                var test = Transformation.Decode(ContainerForDecode, 2);
                Console.WriteLine(test);
                //MessageBox.Show("Анта бака!\nНо все хорошо!\n" + ContainerForDecode.FilePath, "ОК", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception excptn)
            {
                MessageBox.Show("Анта бака!\nОшибка при декодировании!\n" + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGetStatParams_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            var form2 = new Form2(this);
            form2.Show();
        }
    }
}