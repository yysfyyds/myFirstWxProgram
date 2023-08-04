using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yysf_Entity;
using yysf_Entity.BusEntitys;
using yysf_Entity.SysEntitys;

namespace yysf_Entity_Framework
{//数据上下文
    public class SqlDbContext:DbContext
    {
        public SqlDbContext(DbContextOptions options) //options为数据库连接字符串
            : base(options) 
        { 

        }

        //系统表
        public virtual DbSet<SysMenu> SysMenus { get; set; }// 菜单表
        public virtual DbSet<SysUser> SysUsers { get; set; }// 用户表
        public virtual DbSet<Sys_Role> SysRoles { get; set; }// 角色表



        //业务表
        public virtual DbSet<Picture> Pictures { get; set; }// 图片表
        public virtual DbSet<Classify> Classifys { get; set; }// 分类表
        public virtual DbSet<Article> Articles { get; set; }// 文章表


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(queryTrackingBehavior: QueryTrackingBehavior.NoTracking);//关闭EFCore全局追踪，这个会影响查询性能
            base.OnConfiguring(optionsBuilder);
        }
    }
}
