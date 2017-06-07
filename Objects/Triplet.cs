﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AFPParser
{
    public abstract class Triplet : DataStructure
    {
        // Properties which must be implemented by individual triplets
        protected override string StructureName => "Triplet";

        public Triplet(byte[] allData) : base(allData[0], allData[1].ToString("X2"), 2)
        {
            // Set data starting at offset 2
            for (int i = 0; i < Data.Length; i++)
                Data[i] = allData[2 + i];
        }

        public override string GetFullDescription()
        {
            StringBuilder sb = new StringBuilder();

            // Use spaced class name instead of title
            sb.AppendLine($"{SpacedClassName} ({StructureName} 0x{ID})");
            sb.Append(GetOffsetDescriptions());

            return sb.ToString();
        }

        public static string GetAllDescriptions(byte[] tripletData)
        {
            StringBuilder sb = new StringBuilder();

            List<byte[]> triplets = new List<byte[]>();
            int curIndex = 0;
            while (curIndex < tripletData.Length)
            {
                // The first byte is always length, so use that to add each triplet section to the list of byte arrays
                int length = tripletData[curIndex];

                // Add the current triplet to the list
                triplets.Add(tripletData.Skip(curIndex).Take(length).ToArray());

                curIndex += length;
            }

            // Append each triplet's description and data
            foreach (byte[] triplet in triplets)
            {
                // Get the type of triplet
                Type tripletType = typeof(Triplets.UNKNOWN);
                if (Lookups.Triplets.ContainsKey(triplet[1]))
                    tripletType = Lookups.Triplets[triplet[1]];
                Triplet assignedTriplet = (Triplet)Activator.CreateInstance(tripletType, triplet);

                sb.AppendLine(assignedTriplet.GetFullDescription());
            }

            return sb.ToString();
        }

        public override void ParseData()
        {
            // TODO: Remove this if and when each triplet parses the data in their own way
        }
    }
}