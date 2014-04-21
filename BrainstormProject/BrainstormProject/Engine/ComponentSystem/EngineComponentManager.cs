using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

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
            internal set;
        }
        public int TotalActiveComponents
        {
            get
            {
                int ActiveComponents = 0;
                for (int i = 0; i < Components.Count; ++i)
                {
                    
                }
            }
            internal set;
        }
        public List<IRenderable> RenderableComponents { get; internal set; }
        public List<IUpdatable> UpdatableComponents { get; internal set; }
        public List<IEngineComponent> Components { get; internal set; }
        public List<ILoadable> LoadableComponents { get; internal set; }

        public EngineComponentManager()
        {

        }

        public void AddComponent (IEngineComponent Component)
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
    }
}