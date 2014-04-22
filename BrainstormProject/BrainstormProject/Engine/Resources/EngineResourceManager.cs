using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BrainstormProject.Engine.Resources
{
    public class EngineResourceManager
    {
        private GraphicsDevice Device;
        private Game HostGame;
        private List<EngineResource> Resources;

        private Timer ResourceListCleanTask;

        public int ResourceCount
        {
            get
            {
                return Resources.Count;
            }
        }

        public EngineResourceManager(Game HostGame)
        {
            this.HostGame = HostGame;
            Device = HostGame.GraphicsDevice;

            Resources = new List<EngineResource>();

            Device.ResourceCreated   += Device_ResourceCreated;
            Device.ResourceDestroyed += Device_ResourceDestroyed;

            ResourceListCleanTask = new Timer(new TimerCallback(this.CleanResourceList), null, 0, 100);
        }

        void Device_ResourceDestroyed(object sender, ResourceDestroyedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("RESOURCE DESTROYED: " + e.Name) ;
        }

        void Device_ResourceCreated(object sender, ResourceCreatedEventArgs e)
        {
            EngineResource CreatedResource = new EngineResource(e.Resource, this);

            Resources.Add(CreatedResource);

            System.Windows.Forms.MessageBox.Show("RESOURCE CREATED: " + e.Resource.GetType().ToString());
        }


        private void CleanResourceList(object arg)
        {
            for (int i = 0; i < Resources.Count; ++i)
            {
                if (Resources[i].ResourceCollected())
                {
                    Resources.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}