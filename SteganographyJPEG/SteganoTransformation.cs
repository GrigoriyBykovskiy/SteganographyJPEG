using System;
using System.Collections.Generic;
using System.Text;

namespace SteganographyJPEG
{
    public class SteganoTransformation
    {
        public List<double[,]> EncodeCoefficient = new List<double[,]>();
        public List<double[,]> EncodeCoefficientForWrite = new List<double[,]>();
        public List<double[,]> DecodeCoefficient = new List<double[,]>();

        public int u1 = 4; //Координаты коэффициентов, которые будем менять
        public int v1 = 4;
        public int u2 = 5;
        public int v2 = 5;
        //public int P = 250; //Порог изменения коэффициентов

        public string GetBinaryStringFromUInt32(UInt32 value)
        {
            var binaryString = new StringBuilder();
            foreach (byte b in BitConverter.GetBytes(value))
                binaryString.Insert(0, Convert.ToString(b, 2).PadLeft(8, '0'));
            return binaryString.ToString();
        }

        public UInt32 GetUInt32FromBinaryString(string value)
        {
            var arrDataLength = new byte[value.Length / 8];
            var countTmp = 0;
            
            for (var i = 0; i < value.Length; i += 8)
            {
                var ss = value.Substring(countTmp * 8, 8);
                var bv = Convert.ToByte(ss, 2);
                arrDataLength[i / 8] = bv;
                countTmp++;
            }

            Array.Reverse(arrDataLength, 0, 4);
            
            UInt32 outputData = BitConverter.ToUInt32(arrDataLength, 0);

            return outputData;
        }
        public static bool[] Shuffle(bool[] data, Random random)
        {

            for (int i = data.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // swap value data[j] and data[i]
                var temp = data[j];
                data[j] = data[i];
                data[i] = temp;

            }

            return data;
        }
        public void Encode(SteganoContainer container, SteganoMessage steganoMessage, int key, int P)
        {
            if (steganoMessage.Size + 32 > container.Blocks.Count)
            {
                throw new Exception("Размер контейнера слишком мал, сэмпай!");
            }

            //Применили дкп ко всем блокам 8х8
            foreach (var block in container.BlueComponent)
            {
                EncodeCoefficient.Add(DKP.Dkp(block));
            }

            Random rnd = new Random(key);
            bool[] data = new bool[container.BlueComponent.Count - 32];
            
            for (int i = 0; i < steganoMessage.DataBinaryString.Length; i++)
            {
                data[i] = true;
            }

            var distribution = Shuffle(data, rnd);
            var steganoMessageLength = GetBinaryStringFromUInt32(steganoMessage.Size);
            
            // put data about message length in blocks
            for (int counter = 0; counter < 32; counter++)
            {
                EncodeCoefficient[counter] = DKP.CoefficientChange(EncodeCoefficient[counter],
                    steganoMessageLength[counter], u1, v1, u2, v2, P);
            }

            int marker = 32;

            for (int i = 32; i < container.BlueComponent.Count; i++)
            {
                if (marker == steganoMessage.DataBinaryString.Length + 32)
                {
                    break;
                }
                
                if (distribution[i - 32] == true)
                {
                    EncodeCoefficient[i] = DKP.CoefficientChange(EncodeCoefficient[i], steganoMessage.DataBinaryString[marker - 32], u1, v1, u2, v2, P);
                    marker += 1;
                }
                else
                {
                    continue;
                }

            }
            
            foreach (var block in EncodeCoefficient)
            {
                EncodeCoefficientForWrite.Add(DKP.Odkp(block));
            }
            
            // change BlueComponent in container
            for (var counter = 0; counter < container.BlueComponent.Count; counter++)
            {
                byte[,] buf = new byte[8, 8];
                for (uint i = 0; i < 8; i++)
                {
                    for (uint k = 0; k < 8; k++)
                    {
                        if (EncodeCoefficientForWrite[counter][i, k] < 0)
                            buf[i, k] = 0;
                        else if (EncodeCoefficientForWrite[counter][i, k] > 255)
                            buf[i, k] = 255;
                        else
                            buf[i, k] = (byte)Math.Round(EncodeCoefficientForWrite[counter][i, k]);
                    }
                }
                container.BlueComponent[counter] = buf;
            }
        }

        public void Decode(SteganoContainer container, SteganoMessage steganoMessage, int key)
        {
            // Применили ДКП к блокам 8х8
            foreach (var block in container.BlueComponent)
            {
                DecodeCoefficient.Add(DKP.Dkp(block));
            }
            
            double Abs1;
            double Abs2;
            
            string bits = ""; //временная переменная для записи сообщения
            double[,] dkp_8x8; // временная переменная для одной матрицы 8на8 
            
            var steganoMessageLength = "";
            
            for (int counter = 0; counter < 32; counter++)
            {
                dkp_8x8 = DecodeCoefficient[counter];
                Abs1 = Math.Abs(dkp_8x8[u1, v1]);
                Abs2 = Math.Abs(dkp_8x8[u2, v2]);
                if (Abs1 > Abs2)
                    steganoMessageLength += "0";
                if (Abs1 < Abs2)
                    steganoMessageLength += "1";
            }

            var steganoMessageLengthUInt32 = GetUInt32FromBinaryString(steganoMessageLength);
            
            if (steganoMessageLengthUInt32 + 32 > container.Blocks.Count)
            {
                throw new Exception("Контейнер поврежден, сэмпай!");
            }

            Random rnd = new Random(key);
            bool[] data = new bool[container.BlueComponent.Count - 32];
            
            for (int i = 0; i < steganoMessageLengthUInt32; i++)
            {
                data[i] = true;
            }

            var distribution = Shuffle(data, rnd);
            
            for (int k = 32; k < container.Blocks.Count; k++)
            {
                if (distribution[k - 32] == true)
                {
                    dkp_8x8 = DecodeCoefficient[k];
                    Abs1 = Math.Abs(dkp_8x8[u1, v1]);
                    Abs2 = Math.Abs(dkp_8x8[u2, v2]);
                    if (Abs1 > Abs2)
                        bits += "0";
                    if (Abs1 < Abs2)
                        bits += "1";
                }
                else
                {
                    continue;
                }
            }
            steganoMessage.DataBinaryString = bits;
        }
    }
}