using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using BrainstormProject.Engine.ComponentSystem;
using BrainstormProject.Engine.Graphics;

namespace BrainstormProject.Engine.Graphics
{
    public class WorldObject : ILoadable, IUpdatable, IRenderable, IEngineComponent
    {
        private bool Active;

        private bool Dead;
        public string Name { get; internal set; }

        public WorldObject()
        {
            Active = false;
            Dead  = false;
        }
        public virtual void Load()
        {
        }
        public virtual void Update(GameTime gameTime)
        {
        }
        public virtual void Render(GameTime gameTime)
        {
        }
        public bool IsDead()
        {
            return Active;
        }
        public bool IsActive()
        {
            return Dead;
        }
        public bool IsComponentManager()
        {
            return false;
        }
        public void Activate()
        {
            Active = true;
        }
        public void Deactivate()
        {
            Active = false;
        }
        public string GetName()
        {
            return Name;
        }
    }
}