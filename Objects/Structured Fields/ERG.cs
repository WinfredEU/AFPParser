using System.Collections.Generic;

namespace AFPParser.StructuredFields
{
	public class ERG : StructuredField
	{
		private static string _abbr = "ERG";
		private static string _title = "End Resource Group";
		private static string _desc = "The End Resource Group structured field terminates the definition of a resource group initiated by a Begin Resource Group structured field.";
		private static List<Offset> _oSets = new List<Offset>();

		public override string Abbreviation => _abbr;
		public override string Title => _title;
		protected override string Description => _desc;
		protected override bool IsRepeatingGroup => false;
		protected override int RepeatingGroupStart => 0;
		protected override List<Offset> Offsets => _oSets;

		public ERG(int length, string hex, byte flag, int sequence) : base (length, hex, flag, sequence) { }
	}
}