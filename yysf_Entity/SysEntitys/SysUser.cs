using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity
{
    [Table(name:"Sys_User")]
    public class SysUser:BaseEntity<long>
    {
        [Required, StringLength(maximumLength: 50)]//长度限定,Required不可为空
        public string Name { get; set; } = null!;
        [StringLength(maximumLength: 20)]
        public string UserPwd { get; set; }= null!;
        public int FansTotal { get; set; }//粉丝数量
        public int FocusTotal { get; set; }//关注数量
        [ StringLength(maximumLength: 200)]
        public string? Avatar { get; set; } //头像

        public int Sex { get; set; }
        [ StringLength(maximumLength: 20)]
        public string? Email { get; set; }
        [ StringLength(maximumLength: 10)]
        public string? QQ { get; set; }
        [ StringLength(maximumLength: 20)]

        public string? WechatNumber { get; set; }
        [ StringLength(maximumLength: 300)]
        public string? about { get; set; }//自我介绍



    }
}
