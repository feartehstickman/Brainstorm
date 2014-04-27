using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace BrainstormProject.Engine
{
    public class BrainstormEngine : Game
    {
        private GraphicsDeviceManager GraphicsManager;

        public string ApplicationName { get; internal set; }
        
        private List<World> Worlds;
        private World ActiveWorld;

        public Viewport GameViewport
        {
            get
            {
                return GraphicsDevice.Viewport;
            }
        }
        
        public int WorldCount
        {
            get
            {
                return Worlds.Count;
            }
            internal set
            {
                WorldCount = value;
            }
        }

        public BrainstormEngine(string Name)
        {
            ApplicationName = Name;

            GraphicsManager = new GraphicsDeviceManager(this);

            GraphicsManager.PreferredBackBufferWidth  = 800;
            GraphicsManager.PreferredBackBufferHeight = 600;
            GraphicsManager.PreferredBackBufferFormat = SurfaceFormat.Color;
            GraphicsManager.PreferMultiSampling = false;
            GraphicsManager.IsFullScreen = false;
            
            Worlds = new List<World>();
        }
        public BrainstormEngine(string Name,int Width,int Height, bool Fullscreen)
        {
            ApplicationName = Name;

            GraphicsManager = new GraphicsDeviceManager(this);

            GraphicsManager.PreferredBackBufferWidth  = Width;
            GraphicsManager.PreferredBackBufferHeight = Height;
            GraphicsManager.PreferredBackBufferFormat = SurfaceFormat.Color;
            GraphicsManager.PreferMultiSampling       = false;
            GraphicsManager.IsFullScreen              = Fullscreen;
            
            Worlds = new List<World>();
        }
        
        public void AddWorld(World world)
        {
            Worlds.Add (world);
        }
        
        public void SetWorld ( int Index)
        {
            if ( Worlds.Count >= Index)
            {
                ActiveWorld = Worlds[Index];
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
