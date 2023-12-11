using API.BLL_Service;
using API.DAL_Repository.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    [ApiController]
    [Route("api/Time")]

    
    public class TimeController : ControllerBase
    {

        public readonly ITimeService _ITimeService;
        public TimeController(ITimeService iTimeService)
        {
            _ITimeService = iTimeService;
        }

        [HttpGet("GetAllJson")]
        public IActionResult GetAllJson()
        {
            var time = _ITimeService.GetAllJson();
            return Ok(time);
        }
        [HttpGet("GetDataByTimeOfDay")]
        public IActionResult GetDataByTimeOfDay(int timeOfDay=0)
        {
            var data = _ITimeService.GetDataByTimeOfDay(timeOfDay);
            return Ok(data);
        }
        [HttpGet("SumTicket")]
        public IActionResult SumTicket()
        {
            var data = _ITimeService.SumTicket();
            return Ok(data);
        }
        [HttpPost("updateaVailablePlaces")]
        public IActionResult UpdateaVailablePlaces(Time t)
        {

           Time time= _ITimeService.UpdateaVailablePlaces(t);
            return Ok(time);
        }
    }
}
