using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace BrainstormProject.Engine.Resources
{
    public class EngineFileSerializer
    {
        private static object AccessToThis;

        public static EngineFileSerializer()
        {
            AccessToThis = new object();
        }

        public static object Deserialize<T>(string FilePath)
        {
            try
            {
                lock ( AccessToThis )
                {
                    if (File.Exists(FilePath))
                    {
                        FileStream Stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                        XmlSerializer Deserializer = new XmlSerializer(typeof(T));

                        object _object = Deserializer.Deserialize(Stream);
                        
                        return (_object != null) ? _object : new Exception("FAILED");
                    }
                }
            }
            catch (Exception e)
            {
                return e;
            }
            return new Exception("welp");
        }
    }
}