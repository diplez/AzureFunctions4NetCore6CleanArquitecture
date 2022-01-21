using Bit.Contract.Domain.Common.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bit.Contract.Domain.Common.Enums.MonitorEnums;

namespace Bit.Contract.Tests.Services
{
    public class MSMonitorServiceTest
    {
        public static Mock<IMSMonitorService> registerLogInformationService()
        {
            var mock = new Mock<IMSMonitorService>();

            mock.Setup(r => r.registerLogInformation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<OPERATION_ENUM>(), It.IsAny<Guid>()));

            return mock;
        }

        public static Mock<IMSMonitorService> registerErrorInformationService()
        {
            var mock = new Mock<IMSMonitorService>();

            mock.Setup(r => r.registerErrorInformation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<OPERATION_ENUM>(), It.IsAny<Guid>()));

            return mock;
        }
    }
}
