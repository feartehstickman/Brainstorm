using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BrainstormProject.Engine.ComponentSystem;
using BrainstormProject.Engine;

namespace BrainstormProjectTests.EngineTests
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        public void World_Test()
        {
            World TestWorld = new World("TestWorld");

            #region Baseline Tests
            Assert.IsNotNull(TestWorld);
            Assert.IsTrue(TestWorld.IsActive() == true);
            Assert.IsTrue(TestWorld.IsComponentManager() == false);
            Assert.IsTrue(TestWorld.Name != string.Empty);
            #endregion
        }
    }
}