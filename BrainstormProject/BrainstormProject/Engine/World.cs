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

        public string Name { get; internal set; }

        public World()
        {
            Name = "GameWorld";

            WorldObjects = new EngineComponentManager("World_Object_Manager");
        }
        public World(string WorldName)
        {
            Name = WorldName;

            WorldObjects = new EngineComponentManager();
        }

        public bool IsComponentManager()
        {
            return false;
        }
        public bool IsActive()
        {
            throw new NotImplementedException();
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

        public void Update(GameTime gameTime)
        {
            WorldObjects.Update(gameTime);
        }

        public void Render(GameTime gameTime)
        {
            WorldObjects.Render(gameTime);
        }
    }
}