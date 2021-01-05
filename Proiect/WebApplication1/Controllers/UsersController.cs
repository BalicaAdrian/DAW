using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Helpers;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService userService)
        {
            this._service = userService;
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAll()
        {
            var response = _service.GetAll();
            return Ok(response);
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(User payload)
        {
            _service.Update(payload);
            return Ok();
        }

        [HttpPost("set-subscription")]
        [Authorize]
        public IActionResult setSubscription(SetSubscription payload)
        {
            var user = _service.GetById(payload.id);
            user.SubscriptionId = payload.subscriptionId;
            _service.Update(user); 
            return Ok();
        }

        [HttpPost("unset-subscription")]
        [Authorize]
        public IActionResult unsetSubscription(SetSubscription payload)
        {
            var user = _service.GetById(payload.id);
            user.SubscriptionId = null;
            _service.Update(user);
            return Ok();
        }


        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var response = _service.GetByIdAndDetails(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
           
            return Ok(_service.Delete(id));
        }
    }
}
