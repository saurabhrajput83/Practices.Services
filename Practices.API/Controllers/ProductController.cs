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

        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(ILogger<ProductController> logger,
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
                IEnumerable<Product> items = Repository.GetAll();
                return Ok(items);
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
                IEnumerable<Product> items = Repository.GetAllActiveProducts();
                return Ok(items);
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
                Product item = Repository.GetById(id);
                return Ok(item);
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
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                Product entity = Repository.GetById(id);
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
