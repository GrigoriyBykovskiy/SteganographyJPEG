using System;
using System.IO;
using System.Windows.Forms;

namespace SteganographyJPEG
{
    public partial class Form1 : Form
    {
        public string ContainerForEncode;
        public string ContainerForDecode;
        public string InputMessage;

        public int EncodeKey;
        public int DecodeKey;
        // public SteganoContainer ContainerForEncode;
        // public SteganoContainer ContainerForDecode;
        // public SteganoMessage InputMessage;
        // public SteganoMessage OutputMessage;
        // public SteganoTransformation Transformation;
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
                openFileDialog.Filter = "All files (*.*)|*.*|Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png|TXT files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        InputMessage = filePath;
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
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.png; *.bmp|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        ContainerForEncode = filePath;
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
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.png; *.bmp|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        ContainerForDecode = filePath;
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
                int key;
                if (!int.TryParse(textBoxGetEncodeKey.Text, out key))
                {
                    throw new Exception("Ошибка при вводе ключа!");
                }
                
                EncodeKey = Int32.Parse(textBoxGetEncodeKey.Text);

                SteganoTransformation transformation = new SteganoTransformation();
                SteganoContainer container = new SteganoContainer(ContainerForEncode);
                SteganoMessage message = new SteganoMessage(InputMessage);
                container.InitBlocks(8, 8);
                container.InitBlueComponent(8, 8);
                transformation.Encode(container, message, EncodeKey, 250);
                container.InsertBlueComponent(8, 8);
                container.SaveImage(8, 8, "encode_output.bmp");
                
                MessageBox.Show("Успешно!\nФайл находится в директории:\n" + Directory.GetCurrentDirectory(), "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception excptn)
            {
                MessageBox.Show("Анта бака!\nОшибка при кодировании!\n" + excptn.Message + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            try
            {

                if (!int.TryParse(textBoxGetDecodeKey.Text, out DecodeKey))
                {
                    throw new Exception("Ошибка при вводе ключа!");
                }
                
                DecodeKey = Int32.Parse(textBoxGetDecodeKey.Text);
                
                SteganoTransformation transformation = new SteganoTransformation();
                SteganoContainer container = new SteganoContainer(ContainerForDecode);
                SteganoMessage outputMessage = new SteganoMessage();
                container.InitBlocks(8, 8);
                container.InitBlueComponent(8, 8);
                transformation.Decode(container, outputMessage, DecodeKey);
                outputMessage.SaveMessage("decode_output.txt");
                
                MessageBox.Show("Успешно!\nФайл находится в директории:\n" + Directory.GetCurrentDirectory(), "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception excptn)
            {
                MessageBox.Show("Анта бака!\nОшибка при декодировании!\n" + excptn.Message + excptn.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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