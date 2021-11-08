using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Medyana.API.Filters;
using Medyana.API.Model;
using Medyana.Core.Entity;
using Medyana.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace Medyana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidationFilter]
    public class DoctorController : ControllerBase
    {
        private readonly IService<Doctor> _doctorService;
        private readonly IMapper _mapper;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IService<Doctor> doctorService, IMapper mapper, ILogger<DoctorController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _doctorService = doctorService;
            _logger.LogInformation("DoctorController");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorModel>>> GetAllAsync()
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Get");

            var clinics = await _doctorService.GetAllAsync();
            var returnItem = _mapper.Map<IEnumerable<DoctorModel>>(clinics);

            _logger.LogInformation("LogMethodCalled = api/Clinic/Get, Response=" + returnItem);
            return Ok(returnItem);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DoctorModel>> GetAsync(int id)
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Get/id=" + id);

            var clinic = await _doctorService.GetByIdAsync(id);
            var returnItem = _mapper.Map<DoctorModel>(clinic);

            _logger.LogInformation("LogMethodCalled = api/Clinic/Get/id=" + id + ", Response=" + returnItem);
            return Ok(returnItem);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorModel>> Post(DoctorModel model)
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Post");
            var entity = _mapper.Map<Doctor>(model);
            var clinic = await _doctorService.AddAsync(entity);
            var returnItem = _mapper.Map<DoctorModel>(clinic);

            _logger.LogInformation("LogMethodCalled = api/Clinic/Post, Response=" + returnItem);
            return Created("", returnItem);
        }

        [HttpPut]
        public IActionResult Put(DoctorModel model)
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Put");
            var clinic = _doctorService.Update(_mapper.Map<Doctor>(model));
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Delete");
            var repo = _doctorService.GetByIdAsync(id).Result;
            var entity = _mapper.Map<Doctor>(repo);
            _doctorService.Remove(entity);

            return NoContent();
        }
    }
}