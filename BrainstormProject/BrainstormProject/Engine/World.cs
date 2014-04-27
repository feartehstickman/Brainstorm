using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;

using BrainstormProject.Engine.ComponentSystem;
using BrainstormProject.Engine.Graphics;

namespace BrainstormProject.Engine
{
    public class World : IEngineComponent, ILoadable, IUpdatable, IRenderable
    {
        private EngineComponentManager WorldObjects;

        public int WorldObjectCount
        {
            get
            {
                return WorldObjects.TotalComponents;
            }
        }
        public int ActiveWorldObjectCount
        {
            get
            {
                return WorldObjects.TotalActiveComponents;
            }
        }
        public string Name { get; internal set; }

        private bool Active;

        public World()
        {
            Name = "GameWorld";

            WorldObjects = new EngineComponentManager("World_Object_Manager");
        }
        public World(string WorldName)
        {
            Name = WorldName;

            WorldObjects = new EngineComponentManager();

            Activate();
        }

        public bool IsComponentManager()
        {
            return false;
        }
        public bool IsActive()
        {
            return Active;
        }
        public bool IsDead()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return Name;
        }

        public void Load()
        {
            WorldObjects.Load();
        }
        
        public void LoadWorldFromFile(string FilePath)
        {
            throw new NonImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            WorldObjects.Update(gameTime);
        }

        public void Render(GameTime gameTime)
        {
            WorldObjects.Render(gameTime);
        }

        public void Activate()
        {
            Active = true;
        }
        public void Deactivate()
        {
            Active = false;
        }
    }
}
