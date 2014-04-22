using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.InteropServices;

namespace BrainstormProject.Engine.Resources
{
    public sealed class EngineResource : IEngineResource
    {
        private WeakReference ResourceReference;
        public Type ResourceType { get; internal set; }

        public EngineResourceManager Manager;

        public EngineResource(object Resource, EngineResourceManager Parent )
        {
            ResourceReference = new WeakReference(Resource);
            ResourceType = ResourceReference.GetType();
        }

        public bool ResourceCollected()
        {
            return (ResourceReference.IsAlive == true) ? false : true;
        }

        public uint GetSize()
        {
            return (uint)Marshal.SizeOf(ResourceReference);
        }

        public object GetResource()
        {
            return ResourceReference.Target;
        }
    }
}