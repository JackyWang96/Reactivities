using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ActivitiesController : BaseApiController
    {
        private IMediator _mediator;

        // public ActivitiesController(IMediator mediator){
        //     _mediator = mediator;
        // }


        //当你想在响应中包含HTTP状态代码和其他HTTP响应信息时，你应该使用ActionResult<T>作为返回类型
        //这里使用List<Activity>是因为我们预期GetActivities()方法将返回多个Activity对象，而不仅仅是一个。
        //当你在数据库中查询多行数据时，结果通常会是一个集合，如列表。在这个情况下，Activity对象的列表（List<Activity>）被用来表示查询结果。
        //Task是.NET库中表示异步操作的类。一个Task对象表示一个还没有完成的操作，当下是指等获取_context的所有文本后，返回_context.Activities.ToListAsync()
        
        //Get All activities
       [HttpGet] 
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            ////Mediator.Send(new List.Query()) 调用实际上是发送一个新的 List.Query 请求。这个请求会被路由到匹配的处理程序。在你给出的代码中，这个处理程序是 List.Handler。
            return await Mediator.Send(new List.Query());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
        
        //Create the activities
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
        }
        
        //Update the activities
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
        }
        
        
        //Delete the activities
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            //Ok()方法在 ASP.NET Core 中生成一个 ActionResult 对象，该对象表示 HTTP 200 OK 响应状态代码，这通常表示请求已成功处理。
            //如果你提供了一个参数给 Ok() 方法（例如 Ok(someData)），那么这些数据会作为响应体返回给客户端。
            return Ok(new { message = "Operation successful" });
        }
    }
}  