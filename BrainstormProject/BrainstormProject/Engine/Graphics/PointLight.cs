using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using BrainstormProject.Engine.ComponentSystem;

namespace BrainstormProject.Engine.Graphics
{
    public class PointLight : IEngineComponent
    {
        public Vector2 Position;

        public Vector4 Color;

        public float   Intensity;

        public bool Active;

        public string Name;

        /// <summary>
        /// Generic constructor
        /// </summary>
        public PointLight()
        {
        }

        /// <summary>
        /// Constructor with parameters to create point light
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="Color"></param>
        /// <param name="Intensity"></param>
        /// <param name="Active"></param>
        public PointLight(Vector2 Position, Vector4 Color, float Intensity, bool Active)
        {
            this.Position  = Position;
            this.Color     = Color;
            this.Intensity = Intensity;
            this.Active    = Active;
        }

        public void Activate()
        {
            Active = true;
        }
        public void Deactivate()
        {
            Active = false;
        }

        public void SetPosition(Vector2 Position)
        {
            this.Position = Position;
        }

        public bool IsComponentManager()
        {
            return false;
        }

        public bool IsActive()
        {
            return this.IsActive();
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "PointLight";
        }
    }
}