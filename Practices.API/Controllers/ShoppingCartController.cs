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
    public class ShoppingCartController : ControllerBase
    {

        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(ILogger<ShoppingCartController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IShoppingCartRepository Repository { get { return _unitOfWork.ShoppingCartRepository; } }

        [Route("GetAllShoppingCarts")]
        [HttpGet]
        public IActionResult GetAllShoppingCarts()
        {
            try
            {
                IEnumerable<ShoppingCart> items = Repository.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("GetShoppingCartById/{id?}")]
        [HttpGet]
        public IActionResult GetShoppingCartById(int id)
        {
            try
            {
                ShoppingCart item = Repository.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertShoppingCart")]
        [HttpPost]
        public IActionResult InsertShoppingCart(ShoppingCart entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                Repository.Insert(entity);
                _unitOfWork.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("UpdateShoppingCart")]
        [HttpPut]
        public IActionResult UpdateShoppingCart(ShoppingCart entity)
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

        [Route("DeleteShoppingCart")]
        [HttpDelete]
        public IActionResult DeleteShoppingCart(int id)
        {
            try
            {
                ShoppingCart entity = Repository.GetById(id);
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
