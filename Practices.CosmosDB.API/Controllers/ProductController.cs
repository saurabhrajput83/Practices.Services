using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Practices.CosmosDB.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.CosmosDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(IConfiguration config,
            ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _config = config;
            _productRepository = productRepository;

        }

        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                IEnumerable<dynamic> items = await _productRepository.GetAllAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("GetAllActiveProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllActiveProducts()
        {
            try
            {
                IEnumerable<dynamic> items = await _productRepository.GetAllActiveProductsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("GetProductById/{id?}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                dynamic item = await _productRepository.GetByIdAsync(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("InsertProduct")]
        [HttpPost]
        public async Task<IActionResult> InsertProduct(dynamic entity)
        {
            try
            {
                dynamic response = await _productRepository.InsertAsync(entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("UpdateProduct/{id?}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(string id, dynamic entity)
        {
            try
            {
                dynamic response = await _productRepository.UpdateAsync(id, entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("DeleteProduct/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                dynamic response = await _productRepository.DeleteAsync(id); ;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
