using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Enums;
using WebApplication1.Helpers;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;
        public SubscriptionController(ISubscriptionService service)
        {
            this._service = service;
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAll()
        {
            var response = _service.GetAll();
            return Ok(response);
        }


        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        [HttpGet("all/withChannels")]
        [Authorize]
        public IActionResult GetAllWithChannels()
        {
            var response = _service.GetAllwithSubscription();
            return Ok(response);
        }

        [HttpGet("{id}/channels")]
        [Authorize]
        public IActionResult GetChannels(Guid id)
        {
            var response = _service.GetWithChannles(id);
            return Ok(response);
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(Subscription payload)
        {
            _service.Update(payload);
            return Ok();
        }

        [HttpPost("create")]
        [Authorize]
        public IActionResult Create(Subscription payload)
        {
            if (!UserIsInRole(UserTypeEnum.Admin, UserTypeEnum.User))
                return Unauthorized("You are not in role to permit this action");


            return Ok(_service.Insert(payload));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpPost("add-channel")]
        [Authorize]
        public IActionResult addChannel(ModelRelation payload)
        {
            if (!UserIsInRole(UserTypeEnum.Admin, UserTypeEnum.User))
                return Unauthorized("You are not in role to permit this action");

            _service.RegisterChannel(payload);
            return Ok();
        }

        [HttpPost("remove-channel")]
        [Authorize]
        public IActionResult removeChannel(ModelRelation payload)
        {
            if (!UserIsInRole(UserTypeEnum.Admin, UserTypeEnum.User))
                return Unauthorized("You are not in role to permit this action");

            _service.RemoveChannel(payload);
            return Ok();
        }


        private bool UserIsInRole(params UserTypeEnum[] roles)
        {
            var user = GetUserFromContext();
            return roles.Select(x => x.ToString()).Contains(user.Type);
        }

        private User GetUserFromContext() =>
            (User)HttpContext.Items["User"];
    }
}
