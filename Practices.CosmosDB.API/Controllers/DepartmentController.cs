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
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IConfiguration config,
            ILogger<DepartmentController> logger, IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _config = config;
            _departmentRepository = departmentRepository;

        }

        [Route("GetAllDepartments")]
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                IEnumerable<dynamic> items = await _departmentRepository.GetAllAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("GetAllActiveDepartments")]
        [HttpGet]
        public async Task<IActionResult> GetAllActiveDepartments()
        {
            try
            {
                IEnumerable<dynamic> items = await _departmentRepository.GetAllActiveDepartmentsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("GetDepartmentById/{id?}")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentById(string id)
        {
            try
            {
                dynamic item = await _departmentRepository.GetByIdAsync(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("InsertDepartment")]
        [HttpPost]
        public async Task<IActionResult> InsertDepartment(dynamic entity)
        {
            try
            {
                dynamic response = await _departmentRepository.InsertAsync(entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("UpdateDepartment/{id?}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(string id, dynamic entity)
        {
            try
            {
                dynamic response = await _departmentRepository.UpdateAsync(id, entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [Route("DeleteDepartment/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            try
            {
                dynamic response = await _departmentRepository.DeleteAsync(id); ;
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
