using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrainstormProject.Engine.Graphics
{
    public class AlphaBuffer
    {
        public RenderTarget2D AlphaBufferTarget { get; internal set; }
        private GraphicsDevice Device;

        public AlphaBuffer(GraphicsDevice Device)
        {
            this.Device = Device;
        }

        public bool Create()
        {
            try
            {
                AlphaBufferTarget = new RenderTarget2D(Device,
                    Device.Viewport.Width,
                    Device.Viewport.Height,
                    false,
                    SurfaceFormat.Alpha8,
                    DepthFormat.None);

                if (AlphaBufferTarget != null)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);

                return false;
            }
            return false;
        }

        public void BindAlphaBuffer()
        {
            Device.SetRenderTarget(AlphaBufferTarget);
        }

        public void UnbindAlphaBuffer()
        {
            Device.SetRenderTarget(null);
        }

        public void ClearAlphaBuffer()
        {

        }
    }
}