using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SeminarFramework
{
    public class CacheProvider
    {
        static byte[] additionalEntropy = { 2, 6, 7, 8, 4, 3 };
        public void CacheConnections(List<ConnectionString> connections)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ConnectionString>));
                MemoryStream stream = new MemoryStream();
                XmlWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
                xmlSerializer.Serialize(xmlWriter, connections);
                byte[] protectedData = Protect(stream.ToArray());
                File.WriteAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}data.protected", protectedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serialize error data");
            }
        }
        public List<ConnectionString> GetConnectionFromCache()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ConnectionString>));
                byte[] protectedData = File.ReadAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}data.protected");
                byte[] data = Unprotect(protectedData);
                return (List<ConnectionString>)xmlSerializer.Deserialize(new MemoryStream(data));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deserialize error data");
                return null;
            }
        }
        public byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, additionalEntropy, DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException ex) 
            {
                Console.WriteLine("Protect error.");
                return null;
            }
        }
        public byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, additionalEntropy, DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Unprotect error.\n {ex.Message} ");
                return null;
            }
        }
    }
}
