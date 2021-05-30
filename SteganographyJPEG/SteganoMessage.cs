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
        
        // and another data
        
        public SteganoMessage(string pathFile)
        {
            this.FilePath = pathFile;
            this.Data = File.ReadAllBytes(pathFile);
            
            var dataBinaryStringBuf = new StringBuilder();
            
            foreach (byte b in Data)
                dataBinaryStringBuf.Append(Convert.ToString(b, 2).PadLeft(8,'0'));

            this.DataBinaryString = dataBinaryStringBuf.ToString();
        }
    }
}