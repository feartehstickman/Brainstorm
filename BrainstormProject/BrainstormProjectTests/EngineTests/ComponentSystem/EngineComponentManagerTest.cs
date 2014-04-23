using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BrainstormProject.Engine.ComponentSystem;

namespace BrainstormProjectTests.EngineTests.ComponentSystem
{
    public class TestLoadable : ILoadable, IEngineComponent
    {
        public TestLoadable()
        {
            d = false;
        }

        private bool d;

        public void Load()
        {
            d = true;
        }

        public bool IsComponentManager()
        {
            throw new NotImplementedException();
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }

        public bool IsDead()
        {
            return d;
        }

        public string GetName()
        {
            return "TestLoadable";
        }
    }
    public class TestUpdatable : IUpdatable, IEngineComponent
    {
        public TestUpdatable()
        {
            d = false;
        }
        private bool d;

        public void Update(GameTime gameTime)
        {
            d = true;
        }

        public bool IsComponentManager()
        {
            throw new NotImplementedException();
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }

        public bool IsDead()
        {
            return d;
        }

        public string GetName()
        {
            return "TestUpdatable";
        }
    }
    public class TestRenderable : IRenderable, IEngineComponent
    {
        private bool d;
        public TestRenderable()
        {
            d = false;
        }

        public void Render(Microsoft.Xna.Framework.GameTime gameTime)
        {
            d = true;
        }

        public bool IsComponentManager()
        {
            throw new NotImplementedException();
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }

        public bool IsDead()
        {
            return d;
        }

        public string GetName()
        {
            return "TestRenderable";
        }
    }
    public class TestComponent : IEngineComponent
    {
        private bool d;

        public TestComponent()
        {
            d = false;
        }

        public bool IsComponentManager()
        {
            throw new NotImplementedException();
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }

        public bool IsDead()
        {
            return d;
        }

        public void Deactivate()
        {
            d = false;
        }

        public string GetName()
        {
            return "TestComponent";
        }
    }

    [TestClass]
    public class EngineComponentManagerTest
    {
        [TestMethod]
        public void Test()
        {
            #region Setup
            EngineComponentManager TestComponentManager = new EngineComponentManager("UnitTestManager");

            TestLoadable Loadable     = new TestLoadable();
            TestUpdatable Updatable   = new TestUpdatable();
            TestRenderable Renderable = new TestRenderable();
            TestComponent Component   = new TestComponent();
            #endregion

            #region Component Addition Tests
            TestComponentManager.AddComponent(Component);
            Assert.IsTrue((TestComponentManager.TotalComponents          == 1));
            Assert.IsTrue((TestComponentManager.UpdatableComponentCount  == 0));
            Assert.IsTrue((TestComponentManager.RenderableComponentCount == 0));
            Assert.IsTrue((TestComponentManager.LoadableComponentCount   == 0));

            TestComponentManager.AddComponent(Loadable);
            Assert.IsTrue((TestComponentManager.TotalComponents          == 2));
            Assert.IsTrue((TestComponentManager.UpdatableComponentCount  == 0));
            Assert.IsTrue((TestComponentManager.RenderableComponentCount == 0));
            Assert.IsTrue((TestComponentManager.LoadableComponentCount   == 1));

            TestComponentManager.AddComponent(Updatable);
            Assert.IsTrue((TestComponentManager.TotalComponents          == 3));
            Assert.IsTrue((TestComponentManager.UpdatableComponentCount  == 1));
            Assert.IsTrue((TestComponentManager.RenderableComponentCount == 0));
            Assert.IsTrue((TestComponentManager.LoadableComponentCount   == 1));

            TestComponentManager.AddComponent(Renderable);
            Assert.IsTrue((TestComponentManager.TotalComponents          == 4));
            Assert.IsTrue((TestComponentManager.UpdatableComponentCount  == 1));
            Assert.IsTrue((TestComponentManager.RenderableComponentCount == 1));
            Assert.IsTrue((TestComponentManager.LoadableComponentCount   == 1));
            #endregion

            #region Component Removal Tests
            TestComponentManager.RemoveComponentByName("TestLoadable");
            Assert.IsTrue((TestComponentManager.TotalComponents == 3));
            Assert.IsTrue((TestComponentManager.UpdatableComponentCount == 1));
            Assert.IsTrue((TestComponentManager.RenderableComponentCount == 1));
            Assert.IsTrue((TestComponentManager.LoadableComponentCount == 0));

            TestComponentManager.RemoveComponentByName("TestUpdatable");
            Assert.IsTrue((TestComponentManager.TotalComponents == 2));
            Assert.IsTrue((TestComponentManager.UpdatableComponentCount == 0));
            Assert.IsTrue((TestComponentManager.RenderableComponentCount == 1));
            Assert.IsTrue((TestComponentManager.LoadableComponentCount == 0));

            TestComponentManager.RemoveComponentByName("TestRenderable");
            Assert.IsTrue((TestComponentManager.TotalComponents == 1));
            Assert.IsTrue((TestComponentManager.UpdatableComponentCount == 0));
            Assert.IsTrue((TestComponentManager.RenderableComponentCount == 0));
            Assert.IsTrue((TestComponentManager.LoadableComponentCount == 0));

            TestComponentManager.RemoveComponentByName("TestComponent");
            Assert.IsTrue((TestComponentManager.TotalComponents == 0));
            Assert.IsTrue((TestComponentManager.UpdatableComponentCount == 0));
            Assert.IsTrue((TestComponentManager.RenderableComponentCount == 0));
            Assert.IsTrue((TestComponentManager.LoadableComponentCount == 0));
            #endregion
            
            #region Baseline Tests
            Assert.IsTrue(TestComponentManager.IsComponentManager());
            Assert.IsTrue(TestComponentManager.Name != string.Empty);
            Assert.IsTrue(TestComponentManager.IsActive());
            #endregion
        }
    }
}