using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisteredDoctors.Common;
using RegisteredDoctors.Data.Dtos;
using RegisteredDoctors.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisteredDoctors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Doctor : ControllerBase
    {

        private readonly IDoctor _doctorRepository;
        private readonly IMapper _mapper;

        public Doctor(IDoctor doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        [HttpGet()]
        public async Task<IActionResult> CheckDoctorsStatus([FromQuery] string regNumb)
        {

            if (string.IsNullOrEmpty(regNumb))
            {
                ModelState.AddModelError("Registration Number", "The Registration number cannot be empty");
               return BadRequest(Utilities.CreateResponse<DoctorToReturnDTO>("The Registration number cannot be empty", ModelState, null));
            }

           var doctorFromDB = await  _doctorRepository.GetDoctorAsync(regNumb);

            if (doctorFromDB == null)
            {
                ModelState.AddModelError("Doctors Error","The Requested Doctor was not Found");
               return  NotFound(Utilities.CreateResponse<DoctorToReturnDTO>("The Requested Doctor was not Found" , ModelState, null));
            }

            var doctorToReturn = _mapper.Map<DoctorToReturnDTO>(doctorFromDB);

            return Ok(Utilities.CreateResponse("Doctor Was retrieved successfully", null, doctorToReturn));
        }
    }
}
