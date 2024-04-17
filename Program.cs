using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("HelloWord");
        BankData defaultConf = new BankData();
        if (defaultConf.BankDataC.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer");
            int intTemp = Convert.ToInt32(Console.ReadLine());
            if (intTemp <= defaultConf.BankDataC.transfer.threshold)
            {
                Console.WriteLine("Transfer Fee = ", defaultConf.BankDataC.transfer.low_fee);
                Console.WriteLine("Total Amont = ", intTemp + defaultConf.BankDataC.transfer.low_fee);
            }
            else if (intTemp > defaultConf.BankDataC.transfer.threshold)
            {
                Console.WriteLine("Transfer Fee = ", defaultConf.BankDataC.transfer.high_fee);
                Console.WriteLine("Total Amont = ", intTemp + defaultConf.BankDataC.transfer.high_fee);
            }
            Console.WriteLine("Selet Transfer Method");

        }
    }

    public class BankDataConfig
    {
        public string lang { get; set; }
        public TransferData transfer { get; set; }
        public confirmationData confirmation { get; set; }
        public methodsData methods { get; set; }
    }
    public class TransferData
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

    }
    public class confirmationData
    {
        public string en { get; set; }
        public string id { get; set; }
    }
    public class methodsData
    {
        public List<string> c { get; set; }
    }
    public class BankData
    {
        public BankDataConfig BankDataC;
        public BankData()
        {
            ReadJSON();
        }
        public void ReadJSON()
        {
            string fileName = "bank_transfer_config.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            try
            {
                string jsonData = File.ReadAllText(filePath);
                BankDataC = JsonConvert.DeserializeObject<BankDataConfig>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }
        }

    }
}
