using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JSON_Context;
using TelephoneDictionary;

namespace LW3.Util
{
    public class NinjectReg : NinjectModule
    {
        public override void Load()
        {
            Bind<ITelephoneDictionary>().To<JSON_Repository>();
        }
    }
}