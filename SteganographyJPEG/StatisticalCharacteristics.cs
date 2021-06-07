using System;
using System.Drawing;
using System.Threading.Tasks;

namespace SteganographyJPEG
{
    public class StatisticalCharacteristics
    {
        public double RGBMaxValue = 255;
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

        public double getPSNR(SteganoContainer original, SteganoContainer container)
        {
            double mseR = 0;
            double mseG = 0;
            double mseB = 0;
            // Calculate mean square error of R, G, B.
            for (var row = 0; row < container.Image.Height; row++)
            {
                for (var column = 0; column < container.Image.Width; column++)
                {
                    mseR += Math.Pow(original.Image.GetPixel(column, (int)row).R ^ container.Image.GetPixel(column, (int)row).R, 2);
                    mseG += Math.Pow(original.Image.GetPixel(column, (int)row).G ^ container.Image.GetPixel(column, (int)row).G, 2);
                    mseB += Math.Pow(original.Image.GetPixel(column, (int)row).B ^ container.Image.GetPixel(column, (int)row).B, 2);
                }
            }
            // Calculate final value of mean square error
            double MSE = (mseR + mseG + mseB) / ((container.Image.Height * container.Image.Width) * 3);
            // Calculate peak signal to noise ratio
            double PSNR = 10 * Math.Log10(Math.Pow(RGBMaxValue, 2) / MSE);

            return PSNR;
        }

        public double [] getPSNRValues(string original, string message, int maxP, int key)
        {
            double [] PSNRvalues = new double[maxP];
            
            Parallel.For(0, maxP, ctr => {
                SteganoTransformation transformation = new SteganoTransformation();
                SteganoContainer originalImage = new SteganoContainer(original);
                SteganoContainer container = new SteganoContainer(original);
                SteganoMessage originalMessage = new SteganoMessage(message);
                container.InitBlocks(8, 8);
                container.InitBlueComponent(8, 8);
                transformation.Encode(container, originalMessage, key, ctr);
                container.InsertBlueComponent(8, 8);
                container.SaveBitmap(8, 8);
                double buf = getPSNR(originalImage, container);
                PSNRvalues[ctr] = buf;
                container.Image.Dispose();
                originalImage.Image.Dispose();
            });

            return PSNRvalues;
        }
    }
}