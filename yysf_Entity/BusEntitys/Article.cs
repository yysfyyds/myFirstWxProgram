using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity.BusEntitys
{
    [Table(name:"Bus_Article")]
    public class Article:BaseEntity<long>
    {
        [ StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [ForeignKey(name:nameof(Classify))]//定义外键
        public int ClassifyId { get; set; }//分类
        public virtual  Classify Classify { get; set; }

        public int BrowseCount { get; set; }//浏览两
        public int SupportCount { get; set; }//点赞数量
        public int CollectCount { get; set; }//收藏数量
        public int ShareCount { get; set; }
        public string Content { get; set; }//内容
        [StringLength(maximumLength: 100)]
        public string CoverImage { get; set; }//封面
        public int State { get; set; }//文字状态0=在审核1=审核中，2=审核通过，3=审核不通过


    }
}
