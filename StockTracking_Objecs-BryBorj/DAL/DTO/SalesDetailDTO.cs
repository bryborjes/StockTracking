using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockTracking_Objecs_BryBorj.DAL.DTO
{
    public class SalesDetailDTO
    {
        //Ventas ID
        public int SalesID { get; set; }

        //Producto
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        //Cliente
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        //Categoria
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //Cantidad de venta
        public int SalesAmount { get; set; }

        //Total de venta
        public Single SalesPrice { get; set; }

        //Saber el stock
        public int StockAmount { get; set; }

        //Fecha de la venta
        public DateTime SalesDate { get; set; }
        public bool isCategoryDeleted { get; set; }
        public bool isProductDeleted { get; set; }
        public bool isCustomerDeleted { get; set; }
    }
}
