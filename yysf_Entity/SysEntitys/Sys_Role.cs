using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity.SysEntitys
{
    [Table(name:"Sys_Role")]
    public class Sys_Role:BaseEntity<int>
    {
        [Required, StringLength(maximumLength: 30)]
        public string RoleName { get; set; } = null!;//角色名
        [Required, StringLength(maximumLength: 50)]
        public string Desc { get; set; } = null!;//角色介绍
    }
}
