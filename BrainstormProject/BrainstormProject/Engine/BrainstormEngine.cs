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

        public Viewport GameViewport
        {
            get
            {
                return GraphicsDevice.Viewport;
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