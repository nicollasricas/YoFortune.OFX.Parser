using OhMe.Attributes;
using System;
using System.Collections.Generic;

namespace YoFortune.OFX
{
	public class BankAccount
	{
		public BankAccount()
		{
			this.Transactions = new List<BankTransaction>();
		}

		[MapTo("STMTRS/BANKACCTFROM/ACCTID")]
		public string AccountId { get; set; }

		[MapTo("STMTRS/BANKACCTFROM/BANKID")]
		public string BankId { get; set; }

		[MapTo("STMTRS/BANKACCTFROM/BRANCHID")]
		public string BranchId { get; set; }

		[MapTo("STMTRS/CURDEF")]
		public string Currency { get; set; }

		[MapTo("STMTRS/BANKTRANLIST/DTEND")]
		public DateTime StatementEnd { get; set; }

		[MapTo("STMTRS/BANKTRANLIST/DTSTART")]
		public DateTime StatementStart { get; set; }

		[MapTo("STMTRS/BANKTRANLIST/STMTTRN")]
		public List<BankTransaction> Transactions { get; set; }

		[MapTo("STMTRS/BANKACCTFROM/ACCTTYPE")]
		public string Type { get; set; }
	}
}