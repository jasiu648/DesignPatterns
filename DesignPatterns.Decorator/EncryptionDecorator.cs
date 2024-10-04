using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public class EncryptionDataSourceDecorator : DataSourceDecotator
    {
        public EncryptionDataSourceDecorator(IDataSource dataSource) : base(dataSource)
        {
        }

        public override void WriteData(DataFrame dataFrame)
        {
            var encryptedString = EncryptString(dataFrame.Data);
            dataFrame.Data = encryptedString;
            _dataSource.WriteData(dataFrame);
        }
        public override DataFrame ReadData()
        {
            var dataFrame = base.ReadData();
            var decryptedString = DecryptString(dataFrame.Data);
            dataFrame.Data = decryptedString;
            return dataFrame;
        }

        private static string EncryptString(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        private static string DecryptString(string obfuscatedText)
        {
            byte[] obfuscatedBytes = Convert.FromBase64String(obfuscatedText);
            return System.Text.Encoding.UTF8.GetString(obfuscatedBytes);
        }
    }
}
