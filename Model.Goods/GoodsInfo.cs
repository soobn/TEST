using BF.Data.Entities;
using System;

namespace Model.Goods
{
    public class GoodsInfo:BaseEntity<Guid>
    {
       public string WebId { set; get; }
        public string Title { set; get; }
        public bool IsOpen { set; get; }
        public decimal Price { set; get; }
        public decimal OldPrice { set; get; }
        public string Url { set; get; }
        public string Image { set; get; }
        public string Option1Name { set; get; }
        public string Option2Name { set; get; }
        public string Option3Name { set; get; }
        public string Vendor { set; get; }
        public string Types { set; get; }
        public DateTime EditTime { set; get; }
        public DateTime CreatedTime { set; get; }
        public string Description { set; get; }
        public string Introduction { set; get; }
        public int Hot { set; get; }
        public int News { set; get; }
        public int Weight { set; get; }
        public string SortList { set; get; }
        public bool IsDelete { set; get; }
        
    }
}
