using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelephoneDictionary;
using SQL_Context;

namespace LW4.Util
{
    public class NinjectReg : NinjectModule
    {
        public override void Load()
        {
            Bind<ITelephoneDictionary>().To<SQL_Repository>();
        }
    }
}