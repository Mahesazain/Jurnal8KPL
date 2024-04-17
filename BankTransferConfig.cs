using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace modul8_1302220105
{
    internal class BankTransferConfig
    {
        public class TransferData
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set;}

        }
        public class confirmationData
        {
            public string en { get; set; }
            public string id { get; set; }
        }
        public class methodsData
        {
            public string methods { get; set;}
        }
        public class BankData
        {
            public string lang { get; set; }
            public TransferData transfer { get; set; }
            public confirmationData confirmation { get; set; }
            public methodsData methods { get; set; }

        }

        public static void ReadJSON()
        {
            string fileName = "bank_transfer_config.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            try
            {
                string jsonData = File.ReadAllText(filePath);
                BankData bankData = JsonConvert.DeserializeObject<BankData>(jsonData, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }
        }
    }
}
