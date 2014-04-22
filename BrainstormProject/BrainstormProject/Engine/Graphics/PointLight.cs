using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrainstormProject.Engine.Graphics
{
    [Serializable]
    public class PointLight
    {
        [XmlElement]
        public Vector2 Position;

        [XmlElement]
        public Vector4 Color;

        [XmlElement]
        public float   Intensity;

        [XmlElement]
        public bool Active;

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
    }
}