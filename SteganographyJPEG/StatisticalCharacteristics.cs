using System;
using System.Drawing;

namespace SteganographyJPEG
{
    public class StatisticalCharacteristics
    {
        public Color getMaxDifference(SteganoContainer original ,SteganoContainer container)
        {
            // need to add different check params of containers 
            if (container.Image.Height != original.Image.Height ||
                container.Image.Width != original.Image.Width)
            {
                throw new Exception("Размеры изображений не совпадают, сэмпай!");
            }
            
            byte g = Convert.ToByte(0);
            byte b = Convert.ToByte(0);
            byte r = Convert.ToByte(0);
            byte a = Convert.ToByte(0);
            
            
            for (var row = 0; row < container.Image.Height; row++)
            {
                for (var column = 0; column < container.Image.Width; column++)
                {
                    Color pixelOriginal = original.Image.GetPixel((int)column, (int)row);
                    Color pixelContainer = container.Image.GetPixel((int)column, (int)row);
                    byte gBuf = (byte)(pixelOriginal.G ^ pixelContainer.G);
                    byte bBuf = (byte)(pixelOriginal.B ^ pixelContainer.B);
                    byte rBuf = (byte)(pixelOriginal.R ^ pixelContainer.R);
                    byte aBuf = (byte)(pixelOriginal.A ^ pixelContainer.A);

                    if (g < gBuf)
                        g = gBuf;
                    if (b < bBuf)
                        b = bBuf;
                    if (r < rBuf)
                        r = rBuf;
                    if (a < aBuf)
                        a = aBuf;
                }
            }
            
            Color outputData = Color.FromArgb(a, r, g, b);
            
            return outputData;
            
        }
    }
}