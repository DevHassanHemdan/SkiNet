using API.Errors;
using InfraStructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private  StoreContext _storeContext { get; set; }
        public BuggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var thing = _storeContext.Products.Find(828);
            if (thing == null)
                return NotFound(new ApiResponse(404));
            return Ok();
        }

        [HttpGet("serverError")]
        public ActionResult GetServerErrorRequest()
        {
            var thing = _storeContext.Products.Find(828);
            var t = this.ToString();
            if (thing == null)
                return NotFound(new ApiExceptions(500));
            return Ok();
        }

        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        //[HttpGet("notfound")]
        //public ActionResult GetNotFoundRequest()
        //{

        //}

        //[HttpGet("notfound")]
        //public ActionResult GetNotFoundRequest()
        //{

        //}
    }
}
