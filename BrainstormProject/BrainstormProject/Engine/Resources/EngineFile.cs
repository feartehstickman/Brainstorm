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
        public BinaryWriter Writer
        {
            get
            {
                if (FileOpen)
                {
                    return Writer;
                }
            }
            internal set
            {
                Writer = value;
            }
        }
        public BinaryReader Reader
        {
            get
            {
                if(FileOpen)
                {
                    return Reader;
                }
            }
            internal set
            {
                Reader = value;
            }
        }

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
            if (!FileOpen)
            {
                switch (FileAccesRequired)
                {
                    case EngineFileAccess.EngineFileAcces_Read:
                        {
                            Stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
                            break;
                        };
                    case EngineFileAccess.EngineFileAcces_Write:
                        {
                            Stream = File.Open(FilePath, FileMode.Open, FileAccess.Write);
                            break;
                        };
                    case EngineFileAccess.EngineFileAcces_ReadWrite:
                        {
                            Stream = File.Open(FilePath, FileMode.Open, FileAccess.ReadWrite);
                            break;
                        };
                }

                BinaryReader = new BinaryReader(Stream);
                BinaryWriter = new BinaryWriter(Stream);

                FileOpen = true;
                CalculateFileSize();
            }
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
            }
            catch (Exception e)
            {

            }
        }
    }
}
