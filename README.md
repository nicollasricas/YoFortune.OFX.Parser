## YoFortune.OFX

A .NET **OFX** (*[Open Financial Exchange](http://www.ofx.net/)*) parser.

```csharp
var parser = new OFXDocumentParser();

var document = parser.Load(File.ReadAllText("CC17323-09-11.ofx"));

document.BankAccounts[i].BranchId, BankId, AccountId, Transactions...
document.BankAccounts[i].Transactions[i].Amount, Memo, Date, Type...
```


Download/Install
----------

##### GitHub [Releases](https://github.com/nicollasricas/YoFortune.OFX.Parser/releases)
##### Nuget
    Install-Package YoFortune.OFX


Features [Roadmap](ROADMAP.md)
----------

- Parse OFX files
- Support for multiple bank accounts and their transactions
- Support for latin characters


Dependencies
----------

- [OhMe](https://github.com/nicollasricas/OhMe.Mapper)


Changelog [Full Changelog](CHANGELOG.md)
----------

- 1.0
  - Initial version


Contributing
----------

Contributions via pull request are great! 

We use **SPACES** for indentation.


Copyright
----------

Copyright &copy; Nicollas Fernandes Ricas and [contributors](CONTRIBUTORS.md).


License
----------

YoFortune.OFX is licensed under [MIT](https://opensource.org/licenses/MIT).
