using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace BrainstormProject.Engine.ComponentSystem
{
    /// <summary>
    /// Updatable game component
    /// </summary>
    public interface IUpdatable
    {
        void Update(GameTime gameTime);
    }

    /// <summary>
    /// Renderable game component
    /// </summary>
    public interface IRenderable
    {
        void Render(GameTime gameTime);
    }

    /// <summary>
    /// Engine Component
    /// IsComponentManager() returns true if the current component is a component manager, else returns false.
    /// EngineComponentManager is IEngineComponent, IRenderable, IUpdatable and ILoadable
    /// </summary>
    public interface IEngineComponent
    {
        bool IsComponentManager();
        bool IsActive();
        bool IsDead();
        string GetName();
    }

    /// <summary>
    /// Engine Component that needs to load things
    /// </summary>
    public interface ILoadable
    {
        void Load();
    }
}