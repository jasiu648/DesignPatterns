using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class ExternalApi
    {
        public ExternalApi()
        {
            
        }

        public string GetMessage()
        {
            return "ExternalApi Message";
        }
    }

    public class ExternalLibrary
    {
        public ExternalLibrary()
        {
            
        }
        public string GetMessage()
        {
            return "ExternalLibrary Message";
        }
    }

    public class ExternalFramework
    {
        public ExternalFramework() 
        {
            
        }
        public string GetMessage()
        {
            return "ExternalFramework Message";
        }
    }
}
