using System.Collections.Generic;

namespace AFPParser.StructuredFields
{
	public class BFN : StructuredField
	{
		private static string _abbr = "BFN";
		private static string _title = "Begin Font";
		private static string _desc = "Begins the font character set object.";
		private static List<Offset> _oSets = new List<Offset>()
        {
            new Offset(0, Lookups.DataTypes.CHAR, "Font Character Set Name"),
            new Offset(8, Lookups.DataTypes.TRIPS, "")
        };

		public override string Abbreviation => _abbr;
		public override string Title => _title;
		public override string Description => _desc;
		protected override bool IsRepeatingGroup => false;
		protected override int RepeatingGroupStart => 0;
		public override IReadOnlyList<Offset> Offsets => _oSets;

		public BFN(int length, string hex, byte flag, int sequence) : base (length, hex, flag, sequence) { }
	}
}