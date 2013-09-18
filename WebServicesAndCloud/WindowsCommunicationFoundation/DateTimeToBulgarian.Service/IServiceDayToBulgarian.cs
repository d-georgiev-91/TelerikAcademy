using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DateTimeToBulgarian.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceDayToBulgarian" in both code and config file together.
    [ServiceContract]
    public interface IServiceDayToBulgarian
    {

        [OperationContract]
        string GetDayInBulgarian(DateTime date);
    }
}
