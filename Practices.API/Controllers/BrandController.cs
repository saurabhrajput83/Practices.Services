﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practices.API.DAL.Entities;
using Practices.API.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(ILogger<WeatherForecastController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IBrandRepository Repository { get { return _unitOfWork.BrandRepository; } }

        [Route("GetAllBrands")]
        [HttpGet]
        public IActionResult GetAllBrands()
        {
            try
            {
                //string sessionId = this.HttpContext.Request.Form["SessionId"].ToString();
                IEnumerable<Brand> brands = Repository.GetAll();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("GetAllActiveBrands")]
        [HttpGet]
        public IActionResult GetAllActiveBrands()
        {
            try
            {
                IEnumerable<Brand> brands = Repository.GetAllActiveBrands();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Route("GetBrandById/{id?}")]
        [HttpGet]
        public IActionResult GetBrandById(int id)
        {
            try
            {
                Brand brand = Repository.GetById(id);
                return Ok(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertBrand")]
        [HttpPost]
        public IActionResult InsertBrand(Brand entity)
        {
            try
            {
                Repository.Insert(entity);
                _unitOfWork.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("UpdateBrand")]
        [HttpPut]
        public IActionResult UpdateBrand(Brand entity)
        {
            try
            {
                Repository.Update(entity);
                _unitOfWork.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("DeleteBrand")]
        [HttpDelete]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                Brand entity = Repository.GetById(id);
                if (entity != null)
                {
                    Repository.Delete(entity);
                    _unitOfWork.SaveChanges();
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
