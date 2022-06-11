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
    public class ProductController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(ILogger<WeatherForecastController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IProductRepository Repository { get { return _unitOfWork.ProductRepository; } }

        [Route("GetAllProducts")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                IEnumerable<Product> brands = Repository.GetAll();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("GetAllActiveProducts")]
        [HttpGet]
        public IActionResult GetAllActiveProducts()
        {
            try
            {
                IEnumerable<Product> brands = Repository.GetAllActiveProducts();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Route("GetProductById/{id?}")]
        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            try
            {
                Product brand = Repository.GetById(id);
                return Ok(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertProduct")]
        [HttpPost]
        public IActionResult InsertProduct(Product entity)
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

        [Route("UpdateProduct")]
        [HttpPut]
        public IActionResult UpdateProduct(Product entity)
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

        [Route("DeleteProduct")]
        [HttpDelete]
        public IActionResult DeleteProduct(Product entity)
        {
            try
            {
                Repository.Delete(entity);
                _unitOfWork.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
