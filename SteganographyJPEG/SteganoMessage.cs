using System.IO;

namespace SteganographyJPEG
{
    public class SteganoMessage
    {
        public string FilePath;
        public byte[] Data;
        // and another data
        
        public SteganoMessage(string pathFile)
        {
            this.FilePath = pathFile;
            this.Data = File.ReadAllBytes(pathFile);
        }
    }
}