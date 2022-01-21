using Bit.Domain.Common.Dto.Response.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Response.SwaggerModels
{
    public class ModelCatalogResponse<T> : ResponseResultAJAX<IEnumerable<T>>
    {
    }

    public class ModelSubscriptionByClientPartner<T> : ResponseResultAJAX<T>
    {
    }

    public class ModelNotificationsByClient<T> : ResponseResultAJAX<T>
    {
    }

    public class ModelSubscriptionTotal<T> : ResponseResultAJAX<T>
    {
    }

    public class ModelSubscriptionTotalByClient<T> : ResponseResultAJAX<T>
    {
    }

    public class ModelSubscriptionHistoricByClientPartner<T> : ResponseResultAJAX<T>
    {
    }

    public class ModelSubscriptionHistoricByContract<T> : ResponseResultAJAX<T>
    {
    }

    public class ModelSubscriptionByClient<T> : ResponseResultAJAX<T>
    {
    }

    public class ModelLicenceAll<T> : ResponseResultAJAX<T>
    {
    }

    public class ModelActivityLogsAll<T> : ResponseResultAJAX<T>
    {
    }
}
