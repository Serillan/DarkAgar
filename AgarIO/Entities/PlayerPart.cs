﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgarIO.Entities
{
    [ProtoBuf.ProtoContract]
    class PlayerPart : Entity
    {

        [ProtoBuf.ProtoMember(1)]
        public byte Identifier { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public byte DivisionTime { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int MergeTime { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public bool IsOutOfOtherParts { get; set; }

        [ProtoBuf.ProtoIgnore]
        public float Speed
        {
            get
            {
                return ((DivisionTime > 0 ? 30 + NthRoot(Mass, 5): 20 / NthRoot(Mass, 5)));
            }
        }

        private float NthRoot(float A, int N)
        {
            return (float)(Math.Pow(A, 1.0 / N));
        }
    }
}
