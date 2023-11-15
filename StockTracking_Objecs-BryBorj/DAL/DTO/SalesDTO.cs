using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockTracking_Objecs_BryBorj.DAL.DTO
{
    public class SalesDTO
    {
        //Listas
        //Ventas
        public List<SalesDetailDTO> Sales { get; set; }
        //Clientes
        public List<CustomerDetailDTO> Customers { get; set; }
        //Productos
        public List<ProductDetailDTO> Products { get; set; }
        //
        public List<CategoryDetailDTO> Categories { get; set; }
    }
}
