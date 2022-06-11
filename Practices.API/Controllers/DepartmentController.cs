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
    public class DepartmentController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(ILogger<WeatherForecastController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IDepartmentRepository Repository { get { return _unitOfWork.DepartmentRepository; } }

        [Route("GetAllDepartments")]
        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            try
            {
                IEnumerable<Department> brands = Repository.GetAll();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("GetAllActiveDepartments")]
        [HttpGet]
        public IActionResult GetAllActiveDepartments()
        {
            try
            {
                IEnumerable<Department> brands = Repository.GetAllActiveDepartments();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Route("GetDepartmentById/{id?}")]
        [HttpGet]
        public IActionResult GetDepartmentById(int id)
        {
            try
            {
                Department brand = Repository.GetById(id);
                return Ok(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Insert")]
        [HttpPost]
        public IActionResult Insert(Department entity)
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

        [Route("Update")]
        [HttpPut]
        public IActionResult Update(Department entity)
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

        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(Department entity)
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
