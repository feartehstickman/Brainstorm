using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

using BrainstormProject.Engine.ComponentSystem;
using BrainstormProject.Engine.Graphics;

namespace BrainstormProject.Engine
{
    public class World : IEngineComponent
    {
        private EngineComponentManager WorldObjects;

        public string Name { get; internal set; }

        public World()
        {
            Name = "GameWorld";
        }
        public World(string WorldName)
        {
            Name = WorldName;
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
    }
}