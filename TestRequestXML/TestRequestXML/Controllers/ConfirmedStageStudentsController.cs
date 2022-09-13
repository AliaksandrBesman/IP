using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestRequestXML.Models;

namespace TestRequestXML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmedStageStudentsController : ControllerBase
    {
        private readonly graduateprojectsContext _context;

        public ConfirmedStageStudentsController(graduateprojectsContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfirmedStageStudents>>> Get()
        {
            return await _context.ConfirmedStageStudents.ToListAsync();
        }
    }
}
