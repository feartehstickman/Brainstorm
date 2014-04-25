using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;


namespace BrainstormProject.Engine.Resources
{
    public enum EngineFileAccess
    {
        EngineFileAcces_Read = 0,
        EngineFileAcces_Write = 1,
        EngineFileAcces_ReadWrite = 2,
    };

    public sealed class EngineFile : IDisposable
    {
        private FileStream   Stream;
        private BinaryReader BinaryReader;
        private BinaryWriter BinaryWriter;
        private TextReader   TextReader;
        private TextWriter   TextWriter;

        public bool FileOpen { get; internal set; }
        public long FileSize { get; internal set; }

        public EngineFile()
        {
        }

        private void CalculateFileSize()
        {
            if (FileOpen)
            {
                Stream.Seek(0, SeekOrigin.End);
                FileSize = Stream.Position;
                Stream.Seek(0, SeekOrigin.Begin);
            }
        }

        public void OpenFile(string FilePath, EngineFileAccess FileAccesRequired)
        {

        }

        public void Dispose()
        {
            try
            {
                if (Stream != null)
                {
                    Stream.Close();
                    Stream.Dispose();
                }
                if (BinaryReader != null)
                {
                    BinaryReader.Close();
                    BinaryReader.Dispose();
                }
                if (BinaryWriter != null)
                {
                    BinaryWriter.Close();
                    BinaryWriter.Dispose();
                }
                if (TextReader != null)
                {
                    TextReader.Close();
                    TextReader.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}