using System;
using System.Data;

public class Program
{
    static void Main(string[] args) {

        BankTransferConfig config = new BankTransferConfig();
        config.LoadFromJsonFile("bank_transfer_config.json");

        Console.WriteLine(Config.Lang == "en" ? "Please insert the ammount of money to transfer:" : "Masukkan uang yang akan di transfer");

        double amount = double.Parse(Console.ReadLine());
        double fee = amount <= config.Threshold ? config.Lowfee : config.HighFee
        double totalAmount = amount + fee;

        Console.Writeline(config.Lang == "en" ? "Transfer fee = {0:0.00}, Total amount = {1:0.00}" : "Biaya Transfer ={0:0.00}, Total Biaya = {1:0.00}", fee, totalAmount);
        Console.Writeline(config.Lang == "en" ? "Select transfer Method:" : "Pilih Metode Transfer");

        for (int i = 0; i < config.Methods.Count; i++)
        {
            Console.Writeline("{0}.{1}", i + 1, config.Methods[i]);

        }

        int selectMethodIndex = int.Parse(Console.ReadLine()) - 1;
        string selectMethod = config.Methods[selectMethodIndex];

        Console.Write(config.Lang == "en" ? "Please type \"{0}\" to confirm the transaction:") : "Ketik \"{0}\" untuk mengkonfirmasi transaksi", config.Confirmation.En);

        string confirmationInput = Console.ReadLine();

        if (confirmationInput == config.Confirmation.En || confirmationInput == config.Confirmation.Id)
        {
            Console.WriteLine(config.Lang == "en" ? "The transfer is completed" : "Proses transfer berhasil");
        }
        else
        {
            Console.WriteLine(config.Lang == "en" ? "The transfer is cancelled" : "Proses transfer dibatalkan");
        }
    }
}