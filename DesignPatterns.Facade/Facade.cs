using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class Facade
    {
        private ExternalApi _externalApi;
        private ExternalFramework _externalFramework;
        private ExternalLibrary _externalLibrary;

        public Facade()
        {
            _externalApi = new ExternalApi();
            _externalFramework = new ExternalFramework();
            _externalLibrary = new ExternalLibrary();
        }

        public string FacadeOperation()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(_externalApi.GetMessage());
            stringBuilder.Append(_externalFramework.GetMessage());
            stringBuilder.Append(_externalLibrary.GetMessage());

            return stringBuilder.ToString();
        }
    }
}
