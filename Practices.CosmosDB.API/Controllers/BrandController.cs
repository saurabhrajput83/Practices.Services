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
    public class BrandController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<BrandController> _logger;
        private readonly IBrandRepository _brandRepository;

        public BrandController(IConfiguration config,
            ILogger<BrandController> logger, IBrandRepository brandRepository)
        {
            _logger = logger;
            _config = config;
            _brandRepository = brandRepository;

        }

        [Route("GetAllBrands")]
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                IEnumerable<dynamic> items = await _brandRepository.GetAllAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("GetAllActiveBrands")]
        [HttpGet]
        public async Task<IActionResult> GetAllActiveBrands()
        {
            try
            {
                IEnumerable<dynamic> items = await _brandRepository.GetAllActiveBrandsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("GetBrandById/{id?}")]
        [HttpGet]
        public async Task<IActionResult> GetBrandById(string id)
        {
            try
            {
                dynamic item = await _brandRepository.GetByIdAsync(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("InsertBrand")]
        [HttpPost]
        public async Task<IActionResult> InsertBrand(dynamic entity)
        {
            try
            {
                dynamic response = await _brandRepository.InsertAsync(entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("UpdateBrand/{id?}")]
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(string id, dynamic entity)
        {
            try
            {
                dynamic response = await _brandRepository.UpdateAsync(id, entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("DeleteBrand/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            try
            {
                dynamic response = await _brandRepository.DeleteAsync(id); ;
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
