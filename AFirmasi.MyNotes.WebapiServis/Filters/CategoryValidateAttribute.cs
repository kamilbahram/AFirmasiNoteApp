using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AFirmasi.MyNotes.WebapiServis.Filters
{
    public class CategoryValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ServiceResponse<Category> response = new ServiceResponse<Category>
                {
                    HasError = true,
                    Errors = context.ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList()
                };
                context.Result = new BadRequestObjectResult(response);
            }

        }
    }
}
