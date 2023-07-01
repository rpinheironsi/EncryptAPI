using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EncryptAPI
{
    public class Encryptmsg
    {
        public string returnHash { get; private set; }
        public Encryptmsg(string msg)
        {
            string cryptedMsg = onEncrypt(msg);
            returnHash = cryptedMsg;
        }
        private string onEncrypt(string _msg) 
        {
            string dataFolder = "C:\\Users\\rpinh\\source\\repos\\EncryptAPI\\Data\\";
            try
            {
                using (FileStream fileStream = new((dataFolder+"cryptMsg.txt"), FileMode.OpenOrCreate))
                {
                    using (Aes aes = Aes.Create())
                    {
                        string key = File.ReadAllText((dataFolder+"key.txt"));
                        aes.Key = Encoding.ASCII.GetBytes(key);
                        byte[] iv = aes.IV;
                        fileStream.Write(iv, 0, iv.Length);
                        using (CryptoStream cryptoStream = new(fileStream,
                            aes.CreateEncryptor(),
                            CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cryptoStream))
                            {
                                sw.WriteLine(_msg);
                            }
                        }
                    }
                }
            }catch (Exception e) { Console.WriteLine(e.Message); }
            return _msg;
        }
    }
}
