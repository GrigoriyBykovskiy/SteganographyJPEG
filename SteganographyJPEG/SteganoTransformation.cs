using System;
using System.Collections.Generic;

namespace SteganographyJPEG
{
    public class SteganoTransformation
    {
        public List<double[,]> EncodeCoefficient;
        public List<double[,]> EncodeCoefficientForWrite;
        public List<double[,]> DecodeCoefficient;
        public List<double[,]> DecodeCoefficientForWrite;
        public int u1 = 0; //���������� �������������, ������� ����� ������
        public int v1 = 0;
        public int u2 = 1;
        public int v2 = 1;
        public int P = 25; //����� ���������� �������������
        public string message;


        public void Encode(SteganoContainer container, SteganoMessage steganoMessage, int key)
        {
            //��������� ��� �� ���� ������ 8�8
            foreach(var b in container.Blocks)
            {
                Coefficient.Add(DKP.Dkp(b));
            }

            //������ ������������ ���
            for (int i = 0; i < steganoMessage.Data.Length; i++) // Data ����� ���� �� �������� ����, � ������� ��� �������� ���
            {
                Coefficient[i] = DKP.CoefficientChange(Coefficient[i], steganoMessage.Data[i], u1, v1, u2, v2, P);
            }


            foreach(var c in Coefficient)
            {
                CoefficientForWrite.Add(DKP.Odkp(c));
            }


        }

        public void Decode(SteganoContainer container, int key)
        {
            //��������� ��� � ������ 8�8
            foreach (var block in container.Blocks)
            {
                DecodeCoefficient.Add(DKP.Dkp(block));
            }

            double Abs1;
            double Abs2;

            string bits = ""; //��������� ���������� ��� ������ ���������

            List<byte> bytetext = new List<byte>(); //����������� ���������
            double[,] dkp_8x8; // ��������� ���������� ��� ����� ������� 8��8 


            for (int k = 0; k < /*���������� ��������� 8�8*/; k++)
            {
                dkp_8x8 = DecodeCoefficient[k];
                Abs1 = Math.Abs(dkp_8x8[u1, v1]);
                Abs2 = Math.Abs(dkp_8x8[u2, v2]);
                if (Abs1 > Abs2)
                    bits += "0";
                if (Abs1 < Abs2)
                    bits += "1"; 
                if (bits.Length == 8)
                {
                    bytetext.Add(Convert.ToByte(new Bits(bits).Number));
                    bits = "";
                }               
            }

            //� ����� ������ bytetext ������ ���� ���������
            
        }
    }
}