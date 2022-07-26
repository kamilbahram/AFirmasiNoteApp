﻿using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis.Filters;
using AFirmasi.MyNotes.WebapiServis.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFirmasi.MyNotes.WebapiServis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        [CategoryExceptionAttribute]
        public IActionResult Get()
        {
             ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                Entities = categoryService.GetAll(),
                IsSuccessFul = true
            };
            response.EntitiesCount = response.Entities.Count;
            return Ok(response);
        }
        [HttpGet("{id}")]
        [CategoryException]
        public IActionResult Get(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category> 
            {
                Entity  = categoryService.GetById(id),
                IsSuccessFul=true
            };
            return Ok(response);    
        }
        [HttpPost]
        [CategoryException]
        [CategoryValidate]
        public IActionResult Post([FromBody] CategoryModel model)
        {
            Category category = new Category
            {
                CategoryName = model.CategoryName,
            };
            categoryService.Add(category);

            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                Entity = category,
                IsSuccessFul = true
            };
            return Ok();
        }
        [HttpPut]
        [CategoryException]
        [CategoryValidate]
        public IActionResult Put(int id, [FromBody] CategoryModel model)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();
            var category = categoryService.GetById(id);
            if (category == null)
            {
                response.HasError = true;
                response.Errors.Add("kategoriy bulunamadı");
                return BadRequest(response);
            }
            category.CategoryName = model.CategoryName;
            categoryService.Update(category);
            response.IsSuccessFul = true;

            return Ok(response);
        }
        [HttpDelete]
        [CategoryException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();
            var category = categoryService.GetById(id);
            if (category == null)
            {
                response.HasError = true;
                response.Errors.Add("kategoriy bulunamadı");
                return BadRequest(response);
            }
            categoryService.Delete(category);
            response.IsSuccessFul=true;
            return Ok(response);

        }
    }
}
