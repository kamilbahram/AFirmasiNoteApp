﻿using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AFirmasi.MyNotes.WebapiServis.Filters
{
    public class NoteExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note> 
            { 
                HasError = true
            };
            response.Errors.Add("Note Bir hata oluştu" + context.Exception.Message);
            context.Result = new BadRequestObjectResult(response);
        }
    }
}
