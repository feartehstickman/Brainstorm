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

        static EngineFileSerializer()
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

                        Stream.Close();

                        return _object;
                    }
                }
            }
            catch (Exception e)
            {
                return e;
            }
            return new Exception("welp");
        }

        public static void Serialize<T>(string FilePath,T _object)
        {
            try
            {
                lock (AccessToThis)
                {
                    FileStream Stream = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
                    XmlSerializer Serializer = new XmlSerializer(typeof(T));
                    Serializer.Serialize(Stream, _object);

                    Stream.Close();
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}