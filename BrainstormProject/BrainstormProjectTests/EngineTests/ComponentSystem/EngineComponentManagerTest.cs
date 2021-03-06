﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BrainstormProject.Engine.ComponentSystem;
using BrainstormProject.Engine.Performance;

using System.Threading;

namespace BrainstormProjectTests.EngineTests.ComponentSystem
{
    #region Test Classed
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
    public class TestUnloadable : IUnloadable,IEngineComponent
    {
        public TestUnloadable()
        {
            
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
            return false;
        }

        public void Deactivate()
        {
            
        }

        public string GetName()
        {
            return "TestComponent";
        }

        public void Unload()
        {

        }
    }
    #endregion

    [TestClass]
    public class EngineComponentManagerTest
    {
        [TestMethod]
        public void EngineComponentManager_Test()
        {
            #region Setup
            EngineComponentManager TestComponentManager = new EngineComponentManager("UnitTestManager");
            Random r = new Random();

            int MaxTestLoad   = 100;
            int NumLoadables  = r.Next(MaxTestLoad);
            int NumComponents = r.Next(MaxTestLoad);
            int NumUpdatable = r.Next(MaxTestLoad);
            int NumRenderable = r.Next(MaxTestLoad);
            int NumUnloadable = r.Next(MaxTestLoad);

            TestLoadable[] loadables = new TestLoadable[NumLoadables];
            TestUnloadable[] unloadables = new TestUnloadable[NumUnloadable];
            TestUnloadable[] updatables = new TestUnloadable[NumUpdatable];
            TestRenderable[] renderables = new TestRenderable[NumRenderable];
            TestComponent[] components = new TestComponent[NumComponents];

            for (int i = 0; i < NumLoadables; ++i)
            {
                loadables[i] = new TestLoadable();
                TestComponentManager.AddComponent(loadables[i]);
            }
            for (int i = 0; i < NumUnloadable; ++i)
            {
                unloadables[i] = new TestUnloadable();
                TestComponentManager.AddComponent(unloadables[i]);
            }
            for (int i = 0; i < NumUpdatable; ++i)
            {
                updatables[i] = new TestUnloadable();
                TestComponentManager.AddComponent(updatables[i]);
            }
            for (int i = 0; i < NumRenderable; ++i)
            {
                renderables[i] = new TestRenderable();
                TestComponentManager.AddComponent(renderables[i]);
            }
            for (int i = 0; i < NumComponents; ++i)
            {
                components[i] = new TestComponent();
                TestComponentManager.AddComponent(components[i]);
            }
            #endregion

            int TotalExpectedComponentCount = (NumComponents + NumLoadables + NumRenderable + NumUnloadable + NumUpdatable);

            Assert.IsTrue(TestComponentManager.TotalComponents          == TotalExpectedComponentCount);
            Assert.IsTrue(TestComponentManager.UnloadableComponentCount == NumUnloadable);
            Assert.IsTrue(TestComponentManager.UpdatableComponentCount  == NumUpdatable);
            Assert.IsTrue(TestComponentManager.RenderableComponentCount == NumRenderable);
            Assert.IsTrue(TestComponentManager.UnloadableComponentCount == NumUnloadable);
        }
    }
}