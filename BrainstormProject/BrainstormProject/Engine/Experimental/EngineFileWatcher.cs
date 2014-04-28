using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace BrainstormProject.Engine.Experimental
{
    /// <summary>
    /// Data required to determine if a file has been written to since we have checked last
    /// </summary>
    public struct FileWatchData
    {
        public string   FilePath;
        public DateTime LastAccess;
        public DateTime CachedLastAccess;

        /// <summary>
        /// Initializes FileWatchData Structure
        /// </summary>
        /// <param name="FilePath">Path of file to watch. Throws FileNotFoundException</param>
        public FileWatchData(string FilePath)
        {
            if(!File.Exists(FilePath))
                throw new FileNotFoundException();

            this.FilePath = FilePath;

            LastAccess       = File.GetLastWriteTimeUtc(FilePath);
            CachedLastAccess = File.GetLastWriteTimeUtc(FilePath);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class EngineFileWatcher
    {
        private Timer FileWatchTask;

        private List<FileWatchData> Watchlist;

        /// <summary>
        /// 
        /// </summary>
        public EngineFileWatcher()
        {
            Watchlist = new List<FileWatchData>();


        }

        private void WatchFiles()
        {
            if ( Watchlist.Count > 0)
            {

            }
        }
    }
}