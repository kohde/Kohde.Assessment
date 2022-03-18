using Kohde.Assessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment.Implementations
{
    public class SamsungDevice : IDevice
    {
        public string DeviceCode { get; private set; }

        public SamsungDevice()
        {
            this.DeviceCode = "Samsung";
        }
    }
}
