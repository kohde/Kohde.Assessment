using System;
using Kohde.Assessment.Container;
using Xunit;

namespace Kohde.Assessment.UnitTest
{
    public class IoCTestSection
    {
        [Fact]
        public void DependancyInjectionTest()
        {
            Program.PerformIoCActions();

            var deviceProcessor = Ioc.Container.Resolve(typeof(IDeviceProcessor));
            var processor = deviceProcessor as IDeviceProcessor;
            Assert.NotNull(processor); // "IDeviceProcessor has not been implemented correctly"
            // call the GetDevicePrice method
            Console.WriteLine("Device Price: {0:C}", processor.GetDevicePrice());
        }
    }
}
