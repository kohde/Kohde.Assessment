using Kohde.Assessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment.Implementations
{
    public class DeviceProcessor : IDeviceProcessor
    {
        protected IDevice Device { get; private set; }

        public DeviceProcessor(IDevice device)
        {
            this.Device = device;
        }

        public double GetDevicePrice()
        {
            // the actual implementation of this method does not matter....
            return this.Device.DeviceCode.Equals("Samsung") ? 12.95 : 19.95;
        }
    }
}
