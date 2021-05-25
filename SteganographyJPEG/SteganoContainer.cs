using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
            for (uint row = 0; row < Image.Height; row += height)
            {
                for (uint  column = 0; column < Image.Width; column += weight)
                {
                    Rectangle cloneRect = new Rectangle((int)column, (int)row, (int)weight, (int)height);
                    PixelFormat format = Image.PixelFormat;
                    Bitmap cloneBitmap = Image.Clone(cloneRect, format);
                    Color[,] buf = new Color[height, weight];
                    for (uint i = 0; i < height; i++)
                    {
                        for (uint k = 0; k < weight; k++)
                        {
                            buf[i, k] = cloneBitmap.GetPixel((int)k, (int)i);
                        }
                    }
                    Blocks.Add(buf);
                }
            }
        }

        public void TestWriteImage(uint height, uint weight)// block params
        {
            var count = 0;
            for (uint row = 0; row < Image.Height; row += height)
            {
                for (uint  column = 0; column < Image.Width; column += weight)
                {
                    Color[,] buf = Blocks[count];
                    for (uint i = 0; i < height; i++)
                    {
                        for (uint k = 0; k < weight; k++)
                        {
                            Image.SetPixel((int)(k + column), (int)(i + row), buf[i, k]);
                        }
                    }
                    count++;
                }
            }
            Image.Save(Directory.GetCurrentDirectory() + "/test.bmp", ImageFormat.Bmp);
        }
    }
}