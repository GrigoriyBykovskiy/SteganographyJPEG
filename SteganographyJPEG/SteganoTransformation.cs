using System;
using System.Collections.Generic;

namespace SteganographyJPEG
{
    public class SteganoTransformation
    {
        public List<double[,]> EncodeCoefficient = new List<double[,]>();
        public List<double[,]> EncodeCoefficientForWrite = new List<double[,]>();
        public List<double[,]> DecodeCoefficient = new List<double[,]>();
        public List<double[,]> DecodeCoefficientForWrite = new List<double[,]>();
        public int u1 = 0; //���������� �������������, ������� ����� ������
        public int v1 = 0;
        public int u2 = 1;
        public int v2 = 1;
        public int P = 25; //����� ���������� �������������
        //public string message;


        public void Encode(SteganoContainer container, SteganoMessage steganoMessage, int key)
        {
            //��������� ��� �� ���� ������ 8�8
            foreach (var block in container.BlueComponent)
            {
                EncodeCoefficient.Add(DKP.Dkp(block));
            }

            //������ ������������ ���
            for (int i = 0; i < steganoMessage.DataBinaryString.Length; i++) // Data ����� ���� �� �������� ����, � ������� ��� �������� ���
            {
                EncodeCoefficient[i] = DKP.CoefficientChange(EncodeCoefficient[i], steganoMessage.DataBinaryString[i], u1, v1, u2, v2, P); 
            }

            foreach (var block in EncodeCoefficient)
            {
                EncodeCoefficientForWrite.Add(DKP.Odkp(block));
            }
            
            // add code for change BlueComponent in container
            for (var counter = 0; counter < container.BlueComponent.Count; counter++)
            {
                byte[,] buf = new byte[8, 8];
                for (uint i = 0; i < 8; i++)
                {
                    for (uint k = 0; k < 8; k++)
                    {
                        //var test = BitConverter.GetBytes(EncodeCoefficientForWrite[counter][i, k]);
                        buf[i, k] = (byte)Math.Round(EncodeCoefficientForWrite[counter][i, k]);// wrong, need to fix
                    }
                }
                container.BlueComponent[counter] = buf;
            }
        }

        public string Decode(SteganoContainer container, int key)
        {
            // ��������� ��� � ������ 8�8
            foreach (var block in container.BlueComponent)
            {
                DecodeCoefficient.Add(DKP.Dkp(block));
            }
            
            double Abs1;
            double Abs2;
            
            string bits = ""; //��������� ���������� ��� ������ ���������
            
            List<byte> bytetext = new List<byte>(); //����������� ���������
            double[,] dkp_8x8; // ��������� ���������� ��� ����� ������� 8��8 
            
            
            for (int k = 0; k < container.Blocks.Count/*���������� ��������� 8�8*/; k++)
            {
                dkp_8x8 = DecodeCoefficient[k];
                Abs1 = Math.Abs(dkp_8x8[u1, v1]);
                Abs2 = Math.Abs(dkp_8x8[u2, v2]);
                if (Abs1 > Abs2)
                    bits += "0";
                if (Abs1 < Abs2)
                    bits += "1"; 
                /*if (bits.Length == 8)
                {
                    bytetext.Add(Convert.ToByte(new Bits(bits).Number));// what is this?
                    bits = "";
                }*/               
            }

            return bits;
            //� ����� ������ bytetext ������ ���� ���������

        }
    }
}