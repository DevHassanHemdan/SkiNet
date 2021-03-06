﻿using API.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : BaseApiController
    {
        [HttpGet("geterror")]
        public IActionResult GetError(int statusCode)
        {
            return new ObjectResult(new ApiResponse(statusCode));
        }
    }
}
