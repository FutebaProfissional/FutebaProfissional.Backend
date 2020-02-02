using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FutebaProfissional.Domain;
using FutebaProfissional.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FutebaProfissiona.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;

        public GroupController(IGroupService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<GroupViewModel> GetById(Guid id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpGet]
        public ActionResult<List<GroupViewModel>> Get()
        {
            return Ok(_service.GetAll());
        }
    }
}
