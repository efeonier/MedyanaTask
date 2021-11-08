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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace Medyana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidationFilter]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService, IMapper mapper, ILogger<PatientController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _patientService = patientService;
            _logger.LogInformation("PatientController");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientModel>>> GetAllAsync()
        {
            _logger.LogInformation("LogMethodCalled = api/patient/Get");

            var clinics = await _patientService.GetAllAsync();
            var returnItem = _mapper.Map<IEnumerable<PatientModel>>(clinics);

            _logger.LogInformation("LogMethodCalled = api/patient/Get, Response=" + returnItem);
            return Ok(returnItem);
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PatientModel>> GetAsync(int id)
        {
            _logger.LogInformation("LogMethodCalled = api/patient/Get/id=" + id);

            var clinic = await _patientService.GetByIdAsync(id);
            var returnItem = _mapper.Map<PatientModel>(clinic);

            _logger.LogInformation("LogMethodCalled = api/patient/Get/id=" + id + ", Response=" + returnItem);
            return Ok(returnItem);
        }

        [HttpPost]
        public async Task<ActionResult<PatientModel>> Post(PatientModel model)
        {
            _logger.LogInformation("LogMethodCalled = api/Patient/Post");
            var entity = _mapper.Map<Patient>(model);
            var clinic = await _patientService.AddAsync(entity);
            var returnItem = _mapper.Map<PatientModel>(clinic);

            _logger.LogInformation("LogMethodCalled = api/Clinic/Post, Response=" + returnItem);
            return Created("", returnItem);
        }

        [HttpPut]
        public IActionResult Put(PatientModel model)
        {
            _logger.LogInformation("LogMethodCalled = api/Patient/Put");
            var clinic = _patientService.Update(_mapper.Map<Patient>(model));
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("LogMethodCalled = api/Patient/Delete");
            var repo = _patientService.GetByIdAsync(id).Result;
            var entity = _mapper.Map<Patient>(repo);
            _patientService.Remove(entity);

            return NoContent();
        }
    }
}