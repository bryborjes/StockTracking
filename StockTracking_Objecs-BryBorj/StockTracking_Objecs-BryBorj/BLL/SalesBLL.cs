using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL;
using StockTracking_Objecs_BryBorj.DAL.DAO;

namespace StockTracking_Objecs_BryBorj.BLL
{
    class SalesBLL:IBLL<SalesDetailDTO, SalesDTO>
    {
        SalesDAO dao = new SalesDAO();
        ProductDAO productdao = new ProductDAO();
        CategoryDAO categorydao = new CategoryDAO();
        CustomerDAO customerdao = new CustomerDAO();

        public bool Insert(SalesDetailDTO entity)
        {
            SALES sales = new SALES();//Nuevo objeto
            sales.CategoryID = entity.CategoryID;
            sales.ProductID = entity.ProductID;
            sales.CustomerID = entity.CustomerID;
            sales.ProductSalesPrice = entity.SalesPrice;
            sales.ProductSalesAmount = entity.SalesAmount;
            sales.SalesDate = entity.SalesDate;
            dao.Insert(sales);
            //Operacion
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            int temp = entity.StockAmount - entity.SalesAmount;//Calcular cantidad vendida
            product.StockAmount = temp;
            productdao.Update(product);//Actualizar producto
            return true;
        }

        public bool Update(SalesDetailDTO entity)
        {
            SALES sales = new SALES();
            sales.ID = entity.SalesID;
            sales.ProductSalesAmount = entity.SalesAmount;
            dao.Update(sales);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.StockAmount = entity.StockAmount;
            productdao.Update(product);
            return true;
        }

        public bool Delete(SalesDetailDTO entity)
        {
            SALES sales = new SALES();
            sales.ID = entity.SalesID;
            dao.Delete(sales);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.StockAmount += entity.SalesAmount;
            productdao.Update(product);
            return true;
        }

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO();
            dto.Categories = categorydao.Select();
            dto.Customers = customerdao.Select();
            dto.Products = productdao.Select();;
            dto.Sales = dao.Select();
            return dto;
        }
        //Polimorfismo
        public SalesDTO Select(bool isDeleted)
        {
            SalesDTO dto = new SalesDTO();
            dto.Categories = categorydao.Select(isDeleted);
            dto.Customers = customerdao.Select(isDeleted);
            dto.Products = productdao.Select(isDeleted);
            dto.Sales = dao.Select(isDeleted);
            return dto;
        }

        public bool GetBack(SalesDetailDTO entity)
        {
            return dao.GetBack(entity.SalesID);
        }
    }
}
