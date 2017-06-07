using System.Linq;
using System.Collections.Generic;

namespace AFPParser.StructuredFields
{
	public class FNI : StructuredField
	{
		private static string _abbr = "FNI";
		private static string _title = "Font Index";
		private static string _desc = "Maps a descriptive font name to a font member name in a font library.";
		private static List<Offset> _oSets = new List<Offset>()
        {
            new Offset(0, Lookups.DataTypes.CHAR, "Graphic Character GID"),
            new Offset(8, Lookups.DataTypes.UBIN, "Character Increment"),
            new Offset(10, Lookups.DataTypes.SBIN, "Ascender Height"),
            new Offset(12, Lookups.DataTypes.SBIN, "Descender Depth"),
            new Offset(14, Lookups.DataTypes.EMPTY, ""),
            new Offset(16, Lookups.DataTypes.UBIN, "FNM Index"),
            new Offset(18, Lookups.DataTypes.SBIN, "A-Space"),
            new Offset(20, Lookups.DataTypes.SBIN, "B-Space"),
            new Offset(22, Lookups.DataTypes.SBIN, "C-Space"),
            new Offset(24, Lookups.DataTypes.EMPTY, ""),
            new Offset(26, Lookups.DataTypes.SBIN, "Baseline Offset"),
        };

		public override string Abbreviation => _abbr;
		public override string Title => _title;
		public override string Description => _desc;
		protected override bool IsRepeatingGroup => true;
		protected override int RepeatingGroupStart => 0;
        protected override int RepeatingGroupLength
        {
            get
            {
                int length = Data.Length;
                FNC control = LowestLevelContainer.GetStructure<FNC>();
                if (control != null)
                    length = control.Data[15];

                return length;
            }
        }
        public override IReadOnlyList<Offset> Offsets => _oSets;

		public FNI(int length, string hex, byte flag, int sequence) : base (length, hex, flag, sequence) { }
	}
}