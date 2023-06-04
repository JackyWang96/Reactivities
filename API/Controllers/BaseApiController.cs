using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        //Mediator 属性的值是一个表达式，这个表达式的意思是：
        //如果 _mediator 为 null，则从 HttpContext.RequestServices 获取 IMediator 服务并赋值给 _mediator，然后返回 _mediator 的值；否则，直接返回 _mediator 的值。
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}