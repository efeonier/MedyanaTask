using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medyana.API.Model;
using Medyana.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyana.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IPatientService _patientService;

        public NotFoundFilter(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = Convert.ToInt32(context.ActionArguments.Values.FirstOrDefault());
            var patient = await _patientService.GetByIdAsync(id);
            if (patient != null)
            {
                await next();
            }
            else
            {
                var err = new ErrorModel
                {
                    Status = 404
                };
                err.Errors.Add($"id'si {id} olan hasta, veritabanında bulunamadı!");
                context.Result = new NotFoundObjectResult(err);
            }
        }
    }
}