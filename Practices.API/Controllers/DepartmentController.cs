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

        private readonly ILogger<DepartmentController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(ILogger<DepartmentController> logger,
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
                IEnumerable<Department> items = Repository.GetAll();
                return Ok(items);
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
                IEnumerable<Department> items = Repository.GetAllActiveDepartments();
                return Ok(items);
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
                Department item = Repository.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertDepartment")]
        [HttpPost]
        public IActionResult InsertDepartment(Department entity)
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

        [Route("UpdateDepartment")]
        [HttpPut]
        public IActionResult UpdateDepartment(Department entity)
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

        [Route("DeleteDepartment")]
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                Department entity = Repository.GetById(id);
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
