using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BrainstormProject.Engine.Resources;

using System.IO;

namespace BrainstormProjectTests.EngineTests.Resources
{
    [Serializable]
    public class DataClass
    {
        public int a, b, c, d;
    }

    [TestClass]
    public class EngineFileSerializerTest
    {
        [TestMethod]
        public void EngineFileSerializer_Test()
        {
            DataClass d1 = new DataClass();

            d1.a = 123;
            d1.b = 456;
            d1.c = 789;
            d1.d = 101;

            EngineFileSerializer.Serialize<DataClass>("data.dat", d1);

            DataClass d2 = (DataClass)EngineFileSerializer.Deserialize<DataClass>("data.dat");

            Assert.IsTrue(File.Exists("data.dat"));
        }
    }
}