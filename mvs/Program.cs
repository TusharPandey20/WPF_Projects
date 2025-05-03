using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mvs
{
    public class Program
    {
        public static string inputMessage;
        public static string outputMessage;

        public static string currCommand;


        public static string toEncryption = "-e ";
        public static string toDecryption = "-d ";


        static void Main(string[] args)
        {
            try
            {

                for (int i = 0; i <= args.Length; i++)
                {
                    inputMessage = string.Join(" ", args);
                }

                if (inputMessage.StartsWith(toEncryption))
                {
                    string result = inputMessage.Substring(toEncryption.Length);

                    var encryptedMessage = Encryption(result);
                    Console.WriteLine(encryptedMessage);
                }
                else if (inputMessage.StartsWith(toDecryption))
                {
                    string result = inputMessage.Substring(toDecryption.Length);


                    var decryptedMessage = Decryption(result);
                    Console.WriteLine(decryptedMessage);
                }
                else
                {
                    Console.WriteLine("Error!!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excpetion Created in Main : {0}", ex.Message);
            }
        }


        public static string Encryption(string msg)
        {
            try
            {
                byte[] EncryptedTextByte;
                string key = "6RIOJ@&#IOINDIAE8[D0JWJUOW&JEDAW";
                string iv = "UEJKqoep603@&DSE";
                using (AesManaged ObjAesManaged = new AesManaged())
                {
                    ICryptoTransform Encryptor = ObjAesManaged.CreateEncryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(iv));
                    using (MemoryStream ObjMemoryStream = new MemoryStream())
                    {
                        using (CryptoStream ObjCryptoStream = new CryptoStream(ObjMemoryStream, Encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter ObjStreamWriter = new StreamWriter(ObjCryptoStream))
                                ObjStreamWriter.Write(msg);
                            EncryptedTextByte = ObjMemoryStream.ToArray();
                        }
                    }
                }
                return Convert.ToBase64String(EncryptedTextByte);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Decryption(string msg)
        {
            try
            {
                string key = "6RIOJ@&#IOINDIAE8[D0JWJUOW&JEDAW";
                string iv = "UEJKqoep603@&DSE";
                string DecryptedTextByte = null;
                using (AesManaged ObjAesManaged = new AesManaged())
                {
                    ICryptoTransform Decryptor = ObjAesManaged.CreateDecryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(iv));
                    using (MemoryStream ObjMemoryStream = new MemoryStream(Convert.FromBase64String(msg)))
                    {
                        using (CryptoStream ObjCryptoStream = new CryptoStream(ObjMemoryStream, Decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(ObjCryptoStream))
                                DecryptedTextByte = reader.ReadToEnd();
                        }
                    }
                }
                return DecryptedTextByte;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
