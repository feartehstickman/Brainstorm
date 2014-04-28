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
            get;
        }

        public BinaryReader Reader
        {
            get;

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

                Reader = new BinaryReader(Stream);
                Writer = new BinaryWriter(Stream);

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
                if (Reader != null)
                {
                    Reader.Close();
                    Reader.Dispose();
                }
                if (Writer != null)
                {
                    Writer.Close();
                    Writer.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
