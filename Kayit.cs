using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Fatura_Stok
{
    public static class Kayit
    {
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(FaturaStok));
        private static readonly DESCryptoServiceProvider crypto = new DESCryptoServiceProvider();
        private static readonly byte[] key = Encoding.ASCII.GetBytes("ys939604");
        private static readonly string Yol = Path.Combine(Application.StartupPath, "kayitlar");
        public static FaturaStok stok = new FaturaStok();
        public static readonly Dictionary<int, string> aylar = new Dictionary<int, string>() { { 1, "OCAK" }, { 2, "ŞUBAT" }, { 3, "MART" }, { 4, "NİSAN" }, { 5, "MAYIS" }, { 6, "HAZİRAN" }, { 7, "TEMMUZ" }, { 8, "AĞUSTOS" }, { 9, "EYLÜL" }, { 10, "EKİM" }, { 11, "KASIM" }, { 12, "ARALIK" } };

        public static string Kaydet()
        {
            try
            {
                using (FileStream fs = File.Open(Yol, FileMode.Create))
                using (CryptoStream cryptoStream = new CryptoStream(fs, crypto.CreateEncryptor(key, key), CryptoStreamMode.Write))
                    serializer.Serialize(cryptoStream, stok);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Yukle()
        {
            if (File.Exists(Yol))
            {
                try
                {
                    using (FileStream fs = File.Open(Yol, FileMode.Open))
                    using (CryptoStream cryptoStream = new CryptoStream(fs, crypto.CreateDecryptor(key, key), CryptoStreamMode.Read))
                        stok = (FaturaStok)serializer.Deserialize(cryptoStream);
                    return null;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
                return "Dosya bulunamadı";
        }

        public static long GetId<T>(List<T> list) where T : Tablo
        {
            long id = 0;
            foreach (var item in list)
                id = Math.Max(item.Id, id);
            return id + 1;
        }
    }
}
