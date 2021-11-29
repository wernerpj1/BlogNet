using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace back.Filters
{
    public class ValidaCampoFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
             if (!context.ModelState.IsValid)
           {
               var errosCampoModel = new ErrosCamposView(context.ModelState.SelectMany(sm => sm.Value.Errors.Select(s => s.ErrorMessage)));
               context.Result = new BadRequestObjectResult(errosCampoModel);
           }
        }
    }
}