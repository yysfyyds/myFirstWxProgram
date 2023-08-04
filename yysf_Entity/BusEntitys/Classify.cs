using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity.BusEntitys
{
    [Table(name:"Bus_Classify")]
    public class Classify:BaseEntity<int>
    {
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public bool IsShowNav { get; set; }//是否显示在导航栏
    }
}
