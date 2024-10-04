using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
    public class Proxy : IService
    {
        private readonly IService _service;
        private bool _needReset;
        private string cachedMessage;
        public Proxy(IService service)
        {
            _service = service;
            _needReset = true;
        }

        public string ServiceOperation()
        {
            if (_needReset)
            {
                cachedMessage = _service.ServiceOperation();
                _needReset = false;
                return cachedMessage;
            }
            _needReset = true;
            return cachedMessage;
        }
    }
}
