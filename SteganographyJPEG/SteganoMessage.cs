using System;
using System.IO;
using System.Text;

namespace SteganographyJPEG
{
    public class SteganoMessage
    {
        public string FilePath;
        public byte[] Data;
        public string DataBinaryString;
        public UInt32 Size;
        
        // and another data
        public SteganoMessage()
        {
            this.FilePath = "";
            this.Data = null;
            this.DataBinaryString = "";
            this.Size = 0;
        }
        public SteganoMessage(string pathFile)
        {
            this.FilePath = pathFile;
            this.Data = File.ReadAllBytes(pathFile);
            
            var dataBinaryStringBuf = new StringBuilder();
            
            foreach (byte b in Data)
                dataBinaryStringBuf.Append(Convert.ToString(b, 2).PadLeft(8,'0'));

            this.DataBinaryString = dataBinaryStringBuf.ToString();
            
            this.Size = (UInt32)Data.Length * 8;
        }

        public void SaveMessage(string filename)
        {
            var arr = new byte[DataBinaryString.Length / 8];
            var count_tmp = 0;
            
            for (var i = 0; i < DataBinaryString.Length; i += 8)
            {
                var ss = DataBinaryString.Substring(count_tmp * 8, 8);
                var bv = Convert.ToByte(ss, 2);
                arr[i / 8] = bv;
                count_tmp++;
            }
            
            using (BinaryWriter writer = new BinaryWriter(File.Open(Directory.GetCurrentDirectory() + "/" + filename, FileMode.Create)))
            {
                writer.Write(arr, 0, arr.Length);
            }
        }
    }
}