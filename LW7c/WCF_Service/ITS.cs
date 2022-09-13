using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_Service.Models;

namespace WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITS" in both code and config file together.
    [ServiceContract]
    public interface ITS
    {
        [OperationContract]
        List<TelephoneNumber> GetDict();
        [OperationContract]
        TelephoneNumber AddDict(TelephoneNumber telephoneNumber);
        [OperationContract]
        TelephoneNumber UpdDict(TelephoneNumber telephoneNumber);
        [OperationContract]
        TelephoneNumber DelDict(string jj);
    }
}
