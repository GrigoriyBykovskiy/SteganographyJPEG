using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SteganographyJPEG
{
    public class SteganoContainer
    {
        public string FilePath;
        public Bitmap Image;
        public List<Color[,]> Blocks;
        // and another data
        
        public SteganoContainer(string pathFile)
        {
            this.FilePath = pathFile;
            this.Image = new Bitmap(pathFile);
            this.Blocks = new List<Color[,]>();
            // and another code for parse data
        }

        public void InitBlocks(uint height, uint weight) // block params
        {
            for (var row = 0; row < Image.Height; row++)
            {
                //add chunk to blocks
                if (row % height == 0)
                {
                    for (var i = 0; i < (Image.Width / weight); i++)
                    {
                        Color [,] buf = new Color[height, weight];
                        Blocks.Insert(0, buf);
                    }
                }
                
                var count = 0;//list index
                for (var column = 0; column < Image.Width; column++)
                {
                    if (column % weight == 0 && column != 0)
                    {
                        count++;
                    }
                    Color [,] buf = Blocks[count];
                    buf[row % height, column % weight] = Image.GetPixel(column, row);
                }
            }
        }

        public void TestWriteImage(uint height, uint weight)// block params
        {
            Blocks.Reverse();
            for (var row = 0; row < Image.Height; row++)
            {
                var count = 0;//list index
                for (var column = 0; column < Image.Width; column++)
                {
                    if (column % weight == 0 && column != 0)
                    {
                        count++;
                    }
                    Color buf = Blocks[count][row % height, column % weight];
                    Image.SetPixel(column, row, buf);
                }
                if (row % height == 0 && row != 0)
                {
                    Blocks.RemoveRange(0, (int)(Image.Width / weight));
                }
            }
            Image.Save(Directory.GetCurrentDirectory() + "/test.bmp", ImageFormat.Bmp);
        }
    }
}