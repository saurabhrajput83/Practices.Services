using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
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

        private readonly ILogger<BrandController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(ILogger<BrandController> logger,
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
                IEnumerable<Brand> items = Repository.GetAll();
                return Ok(items);
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
                IEnumerable<Brand> items = Repository.GetAllActiveBrands();
                return Ok(items);
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
                Brand item = Repository.GetById(id);
                return Ok(item);
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
