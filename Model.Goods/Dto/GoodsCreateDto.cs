using BF.Web.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Goods.Dto
{
    [AutoMapper.AutoMap(typeof(GoodsInfo))]
    public class GoodsCreateDto: IRequest<ReturnValue<GoodsDto>>
    {
        public Guid WebId { set; get; }
        [StringLength(360, MinimumLength = 6)]
        [Required]
        public string Title { set; get; }
        [Required]
        [Range(0.01, 999999)]
        public decimal Price { set; get; }
        [Required]
        [Range(0.01, 999999)]
        public decimal OldPrice { set; get; }
        [Required]
        [StringLength(360, MinimumLength = 0)]
        public string Url { set; get; }
        [Required]
        [StringLength(80, MinimumLength = 0)]
        public string Option1Name { set; get; }
        [Required]
        [StringLength(80, MinimumLength = 0)]
        public string Option2Name { set; get; }
        [Required]
        [StringLength(80, MinimumLength = 0)]
        public string Option3Name { set; get; }
        public string Vendor { set; get; }
        public string Types { set; get; }
        public string Description { set; get; }
        public string Introduction { set; get; }
        public int Hot { set; get; }
        public int NewsP { set; get; }
        public string Js { set; get; }
        public int Weight { set; get; }
        public string SortList { set; get; }
        public string Image { set; get; }
    }
}
