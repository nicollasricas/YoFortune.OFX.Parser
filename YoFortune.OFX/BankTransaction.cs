using OhMe.Attributes;
using System;

namespace YoFortune.OFX
{
	public class BankTransaction
	{
		[MapTo("TRNAMT")]
		public decimal Amount { get; set; }

		[MapTo("DTPOSTED")]
		public DateTime Date { get; set; }

		[MapTo("FITID")]
		public string Id { get; set; }

		[MapTo("MEMO")]
		public string Memo { get; set; }

		[MapTo("CHECKNUM")]
		public string Number { get; set; }

		[MapTo("TRNTYPE")]
		public string Type { get; set; }
	}
}