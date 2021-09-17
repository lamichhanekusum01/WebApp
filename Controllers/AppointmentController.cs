using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class AppointmentController : Controller
    {
        [HttpPost]
        public IActionResult AddAppointment([FromBody] Appointment appointment)
        {
          return Ok(appointment);
            
        }
    }
}
