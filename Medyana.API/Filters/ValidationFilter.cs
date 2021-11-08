using System.Collections.Generic;
using System.Linq;
using Medyana.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyana.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorModel err = new ErrorModel();
                err.Status = 400;
                IEnumerable<ModelError> errorList = context.ModelState.Values.SelectMany(w => w.Errors);

                errorList.ToList().ForEach(x => { err.Errors.Add(x.ErrorMessage); });
                context.Result = new BadRequestObjectResult(err);
            }

            base.OnActionExecuting(context);
        }
    }
}