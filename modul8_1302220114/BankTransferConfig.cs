using System;
using System.Diagnostics.SymbolStore;
using System.Dynamic;
using System.IO;
using System.Text.Json;

public class BankTransferConfig
{
	public string Lang { get; set; }
	public int Threshold { get; set; }
	public int LowFee { get; set; }
	public int HighFee { get; set; }
	public List<string> Methods { get; set; }
	public Confirmation Confirmation { get; set; }

	public BankTransferConfig()
	{
		Lang = "en";
		Threshold = 25000000;
		LowFee = 6500;
		HighFee = 15000;
		Methods = new List<string> { "RTO(real - time)", "SKN", "RTGS", "BI FAST" };
		Confirmation = new Confirmation { En = "yes", Id = "ya" };
	}

	public void LoadFromJsonFile(string filePath);
	BankTransferConfig config = JsonSerializer.Deserialize<BankTransferConfig>(jsonString);

	Lang = Config.Lang;
	Threshold = Config.Threshold;
	LowFee = Config.LowFee;
	HighFee = Config.HighFee;
	Methods = Config.Methods;
	Confirmation = Config.Confirmation;

		}
}
