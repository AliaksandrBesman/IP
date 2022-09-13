using LW8a.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LW8a.Controllers
{
    public class TSController : Controller
    {
        TelephoneNumberContext ts;

        public TSController(TelephoneNumberContext context)
        {
            ts = context;
        }
        public IActionResult Index()
        {
            return View(ts.telephoneNumbers.ToList());
        }
    }
}
