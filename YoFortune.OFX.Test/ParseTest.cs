using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace YoFortune.OFX.Test
{
	[TestClass]
	public class ParseTest
	{
		[TestMethod]
		public void ParseOFXAsStreamReaderEncodingDefault()
		{
			var parser = new OFXDocumentParser();

			var ofx = parser.Load(new StreamReader(@"Common.ofx", Encoding.Default).ReadToEnd());

			Assert.AreEqual(true, ofx.BankAccounts.Count > 0 && ofx.BankAccounts[0].Transactions.Count > 0);
		}

		[TestMethod]
		public void ParseOFXAsStringNoEncoding()
		{
			var parser = new OFXDocumentParser();

			var ofx = parser.Load(File.ReadAllText("Common.ofx"));

			Assert.AreEqual(true, ofx.BankAccounts.Count > 0 && ofx.BankAccounts[0].Transactions.Count > 0);
		}

		//[TestMethod]
		public void ParseOFXCreditCardsTransactions()
		{
			var parser = new OFXDocumentParser();

			var ofx = parser.Load(File.ReadAllText("CreditCardTransactions.ofx"));

			Assert.AreEqual(true, ofx.BankAccounts.Count > 1 && ofx.BankAccounts[0].Transactions.Count > 0 && ofx.BankAccounts[1].Transactions.Count > 0);
		}

		[TestMethod]
		public void ParseOFXWithMultipleBankAccounts()
		{
			var parser = new OFXDocumentParser();

			var ofx = parser.Load(File.ReadAllText("MultipleBankAccounts.ofx"));

			Assert.AreEqual(true, ofx.BankAccounts.Count > 1 && ofx.BankAccounts[0].Transactions.Count > 0 && ofx.BankAccounts[1].Transactions.Count > 0);
		}
	}
}