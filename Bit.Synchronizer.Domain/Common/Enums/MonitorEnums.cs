using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Domain.Common.Enums
{
    public class MonitorEnums
    {
        public enum OPERATION_ENUM
        {
            READ,
            WRITE,
            FIND,
            DELETE,
            LOGS,
            OTHERS
        }

        public enum TYPE_LOG_ENUM
        {
            INFO,
            ERROR,
            WARN
        }
    }
}
