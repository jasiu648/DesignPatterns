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

}
