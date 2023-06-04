using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application
{
    public class List
    {
        //IRequest 接口来自 MediatR 库，它表示一个请求，请求可以有一个返回类型（在这个例子中是 List<Activity>）。
        //所以，Query 类表示一个请求，这个请求的处理结果是一个 Activity 对象的列表。
        public class Query: IRequest<List<Activity>>{}

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            
            //DataContext 类型的字段 _context，用于与数据库交互。Handler 类的构造函数需要一个 DataContext 参数
            public Handler(DataContext context)
            {
                _context = context;
            }
            
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                //数据库异步地获取所有的 Activity 记录，并将它们转换为列表
                 return await _context.Activities.ToListAsync();
            }
        }
    }
}