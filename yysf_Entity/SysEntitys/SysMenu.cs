using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity.SysEntitys
{//菜单表
    [Table(name:"Sys_Menu")]
    public class SysMenu:BaseEntity<int>
    {
        [Required, StringLength(maximumLength: 50)]
        public string Title { get; set; } = null!;
        [ StringLength(maximumLength: 50)]
        public string Name { get; set; } = null!;
        [StringLength(maximumLength: 50)]
        public string? Icon { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Path { get; set; }=null!;//组件路由访问路径
        [StringLength(maximumLength: 50)]
        public string? CompontName { get; set; }//组件名
        public string? CompontFolder { get; set; }//组件所在文件夹路径

    }
}
