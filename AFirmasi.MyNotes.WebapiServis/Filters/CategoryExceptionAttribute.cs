using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AFirmasi.MyNotes.WebapiServis.Filters
{
    public class CategoryExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                HasError = true
            };
            response.Errors.Add("Categoryde bir hata oluştu" + context.Exception.Message);
            context.Result = new BadRequestObjectResult(response);
        }
    }
}
