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
    public class LineItemController : ControllerBase
    {

        private readonly ILogger<LineItemController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LineItemController(ILogger<LineItemController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public ILineItemRepository Repository { get { return _unitOfWork.LineItemRepository; } }

        [Route("GetAllLineItems")]
        [HttpGet]
        public IActionResult GetAllLineItems()
        {
            try
            {
                IEnumerable<LineItem> items = Repository.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("GetAllLineItemsByShoppingCartId")]
        [HttpGet]
        public IActionResult GetAllLineItemsByShoppingCartId(int shoppingCartId)
        {
            try
            {
                IEnumerable<LineItem> items = Repository.GetAllByShoppingCartId(shoppingCartId);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Route("GetLineItemById/{id?}")]
        [HttpGet]
        public IActionResult GetLineItemById(int id)
        {
            try
            {
                LineItem item = Repository.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertLineItem")]
        [HttpPost]
        public IActionResult InsertLineItem(LineItem entity)
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

        [Route("UpdateLineItem")]
        [HttpPut]
        public IActionResult UpdateLineItem(LineItem entity)
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

        [Route("DeleteLineItem")]
        [HttpDelete]
        public IActionResult DeleteLineItem(int id)
        {
            try
            {
                LineItem entity = Repository.GetById(id);
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
