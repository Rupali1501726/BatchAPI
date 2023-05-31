using BatchAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.ModelBinding;

namespace BatchAPI.Validator
{
    public class CustomValidation:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = new List<Errors>();//new Dictionary<string,string>();

                foreach (var model in context.ModelState)
                {
                    if (model.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                    {
                        var objErrs = new Errors();
                        objErrs.Source = model.Key;
                        objErrs.Description = model.Value.Errors[0].ErrorMessage;
                        errors.Add(objErrs);
                    }
                }

                var responseObj = new
                {
                    CorrelationId = Guid.NewGuid().ToString(),
                    Errors = errors
                };
                context.Result = new JsonResult(responseObj)
                {
                    StatusCode = 400
                };
            }
        }
    }
}
