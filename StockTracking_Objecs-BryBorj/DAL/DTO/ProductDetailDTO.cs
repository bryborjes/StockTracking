using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockTracking_Objecs_BryBorj.DAL.DTO
{
    public class ProductDetailDTO
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int StockAmount { get; set; }
        public Single Price { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public bool isCategoryDeleted { get; set; }
    }
}
