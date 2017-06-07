﻿using System.Collections.Generic;

namespace AFPParser.Triplets
{
    public class UNKNOWN : Triplet
    {
        public override string Description { get { return $"UNKNOWN TRIPLET: {ID}"; } }

        public override IReadOnlyList<Offset> Offsets { get { return new List<Offset>(); } }

        public UNKNOWN(byte[] allData) : base (allData)
        { }
    }
}