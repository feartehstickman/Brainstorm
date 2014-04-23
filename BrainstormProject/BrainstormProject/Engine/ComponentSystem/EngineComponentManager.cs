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
    public class EngineComponentManager : IEngineComponent, ILoadable, IUpdatable, IRenderable
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
                return RenderableComponents.Count;
            }
        }
        public int LoadableComponentCount
        {
            get
            {
                return LoadableComponents.Count;
            }
        }
        public int UpdatableComponentCount
        {
            get
            {
                return UpdatableComponents.Count;
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
        public List<IRenderable> RenderableComponents { get; internal set; }
        public List<IUpdatable> UpdatableComponents { get; internal set; }
        public List<IEngineComponent> Components { get; internal set; }
        public List<ILoadable> LoadableComponents { get; internal set; }
        public string Name { get; internal set; }

        private bool Active;

        private Timer RemoveDeadComponentTask;

        /// <summary>
        /// 
        /// </summary>
        public EngineComponentManager()
        {
            RenderableComponents = new List<IRenderable>();
            UpdatableComponents = new List<IUpdatable>();
            LoadableComponents = new List<ILoadable>();
            Components = new List<IEngineComponent>();
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

            RenderableComponents = new List<IRenderable>();
            UpdatableComponents = new List<IUpdatable>();
            LoadableComponents = new List<ILoadable>();
            Components = new List<IEngineComponent>();
        }

        public void AddComponent(IEngineComponent Component)
        {
            Components.Add(Component);

            if (Component is ILoadable)
            {
                LoadableComponents.Add(Component as ILoadable);
            }
            if (Component is IUpdatable)
            {
                UpdatableComponents.Add(Component as IUpdatable);
            }
            if (Component is IRenderable)
            {
                RenderableComponents.Add(Component as IRenderable);
            }
        }

        public void Load()
        {
            for (int i = 0; i < LoadableComponents.Count; ++i)
            {
                ILoadable CurrentLoadable = LoadableComponents[i] as ILoadable;
                CurrentLoadable.Load();
                IEngineComponent CurrentCompoent = LoadableComponents[i] as IEngineComponent;
                if (CurrentCompoent.IsComponentManager())
                {
                    EngineComponentManager ManagerSubcomponent = LoadableComponents[i] as EngineComponentManager;
                    ManagerSubcomponent.Load();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < UpdatableComponents.Count; ++i)
            {
                IUpdatable CurrentUpdatable = UpdatableComponents[i] as IUpdatable;

                CurrentUpdatable.Update(gameTime);

                IEngineComponent CurrentComponent = UpdatableComponents[i] as IEngineComponent;
                if (CurrentComponent.IsComponentManager())
                {
                    EngineComponentManager ManagerSubcomponent = UpdatableComponents[i] as EngineComponentManager;
                    ManagerSubcomponent.Update(gameTime);
                }
            }
        }

        public void Render(GameTime gameTime)
        {
            for (int i = 0; i < RenderableComponents.Count; ++i)
            {
                IRenderable CurrentRenderable = RenderableComponents[i] as IRenderable;

                CurrentRenderable.Render(gameTime);

                IEngineComponent CurrentComponent = RenderableComponents[i] as IEngineComponent;
                if (CurrentComponent.IsComponentManager())
                {
                    EngineComponentManager ManagerSubcomponent = RenderableComponents[i] as EngineComponentManager;
                    ManagerSubcomponent.Render(gameTime);
                }
            }
        }

        private void RemoveDeadComponents()
        {
            for (int i = 0; i < Components.Count; ++i)
            {
                if ( Components[i].)
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