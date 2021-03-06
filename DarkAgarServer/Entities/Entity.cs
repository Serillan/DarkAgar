﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAgarServer.Entities
{
    /// <summary>
    /// Represents the game entity.
    /// </summary>
    [ProtoBuf.ProtoContract]
    [ProtoBuf.ProtoInclude(5, typeof(Food))]
    [ProtoBuf.ProtoInclude(6, typeof(Player))]
    [ProtoBuf.ProtoInclude(7, typeof(PlayerPart))]
    [ProtoBuf.ProtoInclude(8, typeof(Virus))]
    abstract class Entity
    {
        /// <summary>
        /// Gets or sets the mass.
        /// </summary>
        /// <value>The mass.</value>
        [ProtoBuf.ProtoMember(1)]
        public int Mass { get; set; }

        /// <summary>
        /// Gets the radius.
        /// </summary>
        /// <value>The radius.</value>
        [ProtoBuf.ProtoIgnore]
        public float Radius => 10 * (float)Math.Sqrt(Mass / Math.PI);

        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        /// <value>The x.</value>
        [ProtoBuf.ProtoMember(3)]
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        /// <value>The y.</value>
        [ProtoBuf.ProtoMember(4)]
        public float Y { get; set; }
    }
}
