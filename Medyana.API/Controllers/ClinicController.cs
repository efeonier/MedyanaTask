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
using Microsoft.Extensions.Logging;

namespace Medyana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidationFilter]
    public class ClinicController : ControllerBase
    {
        private readonly IService<Clinic> _clinicService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClinicController> _logger;

        public ClinicController(IService<Clinic> clinicService, IMapper mapper, ILogger<ClinicController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _clinicService = clinicService;
            _logger.LogInformation("ClinicController");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClinicModel>>> GetAllAsync()
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Get");

            var clinics = await _clinicService.GetAllAsync();
            var returnItem = _mapper.Map<IEnumerable<ClinicModel>>(clinics);

            _logger.LogInformation("LogMethodCalled = api/Clinic/Get, Response=" + returnItem);
            return Ok(returnItem);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClinicModel>> GetAsync(int id)
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Get/id=" + id);

            var clinic = await _clinicService.GetByIdAsync(id);
            var returnItem = _mapper.Map<ClinicModel>(clinic);

            _logger.LogInformation("LogMethodCalled = api/Clinic/Get/id=" + id + ", Response=" + returnItem);
            return Ok(returnItem);
        }

        [HttpPost]
        public async Task<ActionResult<ClinicModel>> Post(ClinicModel model)
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Post");
            var entity = _mapper.Map<Clinic>(model);
            var clinic = await _clinicService.AddAsync(entity);
            var returnItem = _mapper.Map<ClinicModel>(clinic);

            _logger.LogInformation("LogMethodCalled = api/Clinic/Post, Response=" + returnItem);
            return Created("", returnItem);
        }

        [HttpPut]
        public IActionResult Put(ClinicModel model)
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Put");
            var clinic = _clinicService.Update(_mapper.Map<Clinic>(model));
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("LogMethodCalled = api/Clinic/Delete");
            var repo = _clinicService.GetByIdAsync(id).Result;
            var entity = _mapper.Map<Clinic>(repo);
            _clinicService.Remove(entity);

            return NoContent();
        }
    }
}