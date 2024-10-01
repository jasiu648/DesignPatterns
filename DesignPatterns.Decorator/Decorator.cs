using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public class DataFrame
    {
        public string Data;
    }
    public interface IDataSource
    {
        public void WriteData(DataFrame dataFrame);
        public DataFrame ReadData();
    }

    public class FileDataSource : IDataSource
    {
        private string _filePath;

        public FileDataSource(string filePath)
        {
            _filePath = filePath;
        }
        public void WriteData(DataFrame dataFrame)
        {
            File.WriteAllText(_filePath, dataFrame.Data);
        }
        public DataFrame ReadData()
        {
            var content = File.ReadAllText(_filePath);
            var dataFrame = new DataFrame();
            dataFrame.Data = content;
            return dataFrame;
        }
    }

    public class DataSourceDecotator : IDataSource
    {
        protected IDataSource _dataSource;

        public DataSourceDecotator(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public virtual void WriteData(DataFrame dataFrame)
        {
            _dataSource.WriteData(dataFrame);
        }
        public virtual DataFrame ReadData()
        {
            return _dataSource.ReadData();
        }
    }

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
