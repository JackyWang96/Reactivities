using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options){
            
        }

        //DbSet<T>中的T是一个Entity类，代表了表中的一个行记录。Entity类通常包含了一些公开的属性，这些属性对应了数据库表中的列。
        //DbSet<Activity> Activities 表示的是一个类型为 DbSet<Activity> 的属性，名称为 Activities
        //在 DbSet<T> 中，T 是一个类型参数，它表示在数据库中要操作的实体类型。在 Entity Framework 中，一个实体通常对应数据库中的一张表，实体的属性对应表的列。
        public DbSet<Activity>Activities {get; set;}
    }
}