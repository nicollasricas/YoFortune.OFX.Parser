using OhMe.Attributes;
using System.Collections.Generic;

namespace YoFortune.OFX
{
	[MapPath("OFX")]
	public class OFXDocument
	{
		public OFXDocument()
		{
			this.BankAccounts = new List<BankAccount>();
		}

		[MapTo("BANKMSGSRSV1/STMTTRNRS")]
		public List<BankAccount> BankAccounts { get; set; }
	}
}