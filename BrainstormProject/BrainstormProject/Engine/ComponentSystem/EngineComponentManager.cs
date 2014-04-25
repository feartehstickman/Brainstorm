using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;

using Microsoft.Xna.Framework;
using MonoGame.Framework;

namespace BrainstormProject.Engine.ComponentSystem
{
    public sealed class EngineComponentManager : IEngineComponent, ILoadable, IUpdatable, IRenderable
    {
        public string ComponentName { get; internal set; }
        public int TotalComponents
        {
            get
            {
                return Components.Count;
            }
            set
            {
            }
        }
        public int RenderableComponentCount
        {
            get
            {
                int n = 0;
                for (int i = 0; i < TotalComponents; ++i)
                {
                    if (Components[i] is IRenderable)
                    {
                        n++;
                    }
                }
                return n;
            }
        }
        public int LoadableComponentCount
        {
            get
            {
                int n = 0;
                for (int i = 0; i < TotalComponents; ++i)
                {
                    if (Components[i] is ILoadable)
                    {
                        n++;
                    }
                }
                return n;
            }
        }
        public int UpdatableComponentCount
        {
            get
            {
                int n = 0;
                for (int i = 0; i < TotalComponents; ++i)
                {
                    if (Components[i] is IUpdatable)
                    {
                        n++;
                    }
                }
                return n;
            }
        }
        public int UnloadableComponentCount
        {
            get
            {
                int n = 0;
                for (int i = 0; i < TotalComponents; ++i)
                {
                    if (Components[i] is IUnloadable)
                    {
                        n++;
                    }
                }
                return n;
            }
        }
        public int TotalActiveComponents
        {
            get
            {
                int ActiveComponents = 0;
                for (int i = 0; i < Components.Count; ++i)
                {
                    if (Components[i].IsActive())
                    {
                        ActiveComponents++;
                    }
                }
                return ActiveComponents;
            }
            private set
            {
                TotalActiveComponents = value;
            }
        }

        
        public List<IEngineComponent> Components { get; internal set; }
        public string Name { get; internal set; }

        private bool Active;

        private Timer RemoveDeadComponentTask;

        /// <summary>
        /// 
        /// </summary>
        public EngineComponentManager()
        {
            Components = new List<IEngineComponent>();

            Active = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name">Name of this component manager</param>
        public EngineComponentManager(string Name)
        {
            if (Name != string.Empty)
            {
                this.Name = Name;
            }

            Components = new List<IEngineComponent>();

            Active = true;
        }

        public void AddComponent(IEngineComponent Component)
        {
            Components.Add(Component);
        }

        public void Load()
        {
            for (int i = 0; i < TotalComponents; ++i)
            {
                if (Components[i] is ILoadable)
                {
                    ILoadable CurrentLoadable = Components[i] as ILoadable;

                    CurrentLoadable.Load();

                    if (Components[i].IsComponentManager())
                    {
                        EngineComponentManager Submanager = Components[i] as EngineComponentManager;

                        Submanager.Load();
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < TotalComponents; ++i)
            {
                if (Components[i] is IUpdatable)
                {
                    IUpdatable CurrentUpdatable = Components[i] as IUpdatable;

                    CurrentUpdatable.Update(gameTime);

                    if (Components[i].IsComponentManager())
                    {
                        EngineComponentManager Submanager = Components[i] as EngineComponentManager;

                        Submanager.Update(gameTime);
                    }
                }
            }
        }

        public void Render(GameTime gameTime)
        {
            for (int i = 0; i < TotalComponents; ++i)
            {
                if (Components[i] is IRenderable)
                {
                    IRenderable CurrentRenderable = Components[i] as IRenderable;

                    CurrentRenderable.Render(gameTime);

                    if (Components[i].IsComponentManager())
                    {
                        EngineComponentManager Submanager = Components[i] as EngineComponentManager;

                        Submanager.Render(gameTime);
                    }
                }
            }
        }

        public void Unload()
        {
            for (int i = 0; i < TotalComponents; ++i)
            {
                if (Components[i] is IUnloadable)
                {
                    IUnloadable CurrentUnloadable = Components[i] as IUnloadable;

                    CurrentUnloadable.Unload();

                    if (Components[i].IsComponentManager())
                    {
                        EngineComponentManager Submanager = Components[i] as EngineComponentManager;
                        Submanager.Unload();
                    }
                }
            }
        }

        private void RemoveDeadComponents()
        {
            try
            {
                if (Components.Count > 0)
                {
                    for (int i = 0; i < Components.Count; ++i)
                    {
                        if (Components[i].IsDead())
                        {
                            Components.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // log this, do something.
            }
        }

        public void RemoveComponentByName(string Name)
        {
            try
            {
                for (int i = 0; i < TotalComponents; ++i)
                {
                    if (Components[i].GetName() == Name)
                    {
                        Components.RemoveAt(i);
                        i--;
                    }
                }
            }
            catch (Exception e)
            {
                // log this
            }
        }

        public string GetName()
        {
            if (this.Name == string.Empty)
            {
                return "Unnamed Engine Component Manager";
            }
            return this.Name;
        }
        public bool IsDead()
        {
            throw new NotImplementedException();
        }
        public bool IsComponentManager()
        {
            return true;
        }
        public bool IsActive()
        {
            return this.Active;
        }
        public void Activate()
        {
            if (!Active)
                Active = true;
        }
        public void Deactivate()
        {
            if (Active)
                Active = false;
        }
    }
}