using back.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

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