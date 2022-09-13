using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDictionary
{
    public interface ITelephoneDictionary
    {
        IEnumerable<TelephoneNumber> List();
        TelephoneNumber Find(int id);
        TelephoneNumber Add(TelephoneNumber item);
        TelephoneNumber Remove(int item);
        TelephoneNumber Edit(TelephoneNumber item);
        void Save();
    }
}
