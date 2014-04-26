using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;

using BrainstormProject.Engine;
using BrainstormProject.Engine.ComponentSystem;
using BrainstormProject.Engine.Resources;
using BrainstormProject.Engine.Performance;

namespace BrainstormProject.Engine.Experimental
{
    public static class Load
    {
        private static object AccessToThis;

        static Load()
        {
            AccessToThis = new object();
        }

        public static object FromFile<T>(string FilePath)
        {
            lock (AccessToThis)
            {
                try
                {
                    if (File.Exists(FilePath))
                    {
                        Type ObjectType = typeof(T);

                        PropertyInfo[] ObjectPropertyInfo = ObjectType.GetProperties(BindingFlags.CreateInstance);
                        
                        foreach (PropertyInfo info in ObjectPropertyInfo)
                        {
                            if (info.PropertyType == typeof(string) && info.Name == "FILE_LOADABLE")
                            {
                                EngineFile ClassFile = new EngineFile();

                                ClassFile.OpenFile(FilePath, EngineFileAccess.EngineFileAcces_Read);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}