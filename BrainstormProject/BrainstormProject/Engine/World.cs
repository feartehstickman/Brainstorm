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
    }
}