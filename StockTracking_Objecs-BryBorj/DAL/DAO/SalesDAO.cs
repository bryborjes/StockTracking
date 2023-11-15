using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL;
using System.Runtime.CompilerServices;

namespace StockTracking_Objecs_BryBorj.DAL.DAO
{
    class SalesDAO : StockContext, IDAO<SALES, SalesDetailDTO>
    {
        ProductDAO productDAO = new ProductDAO();
        public List<SalesDetailDTO> Select()
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALES.Where(x => x.isDeleted == false) //Enlazar tablas
                            join p in db.PRODUCT on s.ProductID equals p.ID
                            join c in db.CUSTOMERS on s.CustomerID equals c.ID
                            join category in db.CATEGORY on s.CategoryID equals category.ID
                            select new
                            {
                                productname = p.ProductName,
                                customername = c.CustomerName,
                                categoryname = category.CategoryName,
                                productid = s.ProductID,
                                salesID = s.ID,
                                categoryID = s.ID,
                                customerID = s.CustomerID,
                                salesprice = s.ProductSalesPrice,
                                salesamount = s.ProductSalesAmount,
                                salesdate = s.SalesDate,
                                stockamount = p.StockAmount
                            }).OrderBy(x => x.salesdate).ToList();
                foreach (var item in list)//Hace un recorrido por toda la tabla
                {
                    SalesDetailDTO dto = new SalesDetailDTO();
                    dto.ProductName = item.productname;
                    dto.CustomerName = item.customername;
                    dto.CategoryName = item.categoryname;
                    dto.CategoryID = item.categoryID;
                    dto.CustomerID = item.customerID;
                    dto.ProductID = item.productid;
                    dto.SalesID = item.salesID;
                    dto.SalesPrice = item.salesprice;
                    dto.SalesDate = item.salesdate;
                    dto.SalesAmount = item.salesamount;
                    dto.StockAmount = item.stockamount;
                    sales.Add(dto);
                }
                return sales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALES.Where(x => x.isDeleted == isDeleted) //Enlazar tablas
                            join p in db.PRODUCT on s.ProductID equals p.ID
                            join c in db.CUSTOMERS on s.CustomerID equals c.ID
                            join category in db.CATEGORY on s.CategoryID equals category.ID
                            select new
                            {
                                productname = p.ProductName,
                                customername = c.CustomerName,
                                categoryname = category.CategoryName,
                                productid = s.ProductID,
                                salesID = s.ID,
                                categoryID = s.ID,
                                customerID = s.CustomerID,
                                salesprice = s.ProductSalesPrice,
                                salesamount = s.ProductSalesAmount,
                                salesdate = s.SalesDate,
                                stockamount = p.StockAmount,
                                categoryDeleted = category.isDeleted,
                                productDeleted = p.isDeleted,
                                customerDeleted = c.idDeleted
                            }).OrderBy(x => x.salesdate).ToList();
                foreach (var item in list)//Hace un recorrido por toda la tabla
                {
                    SalesDetailDTO dto = new SalesDetailDTO();
                    dto.ProductName = item.productname;
                    dto.CustomerName = item.customername;
                    dto.CategoryName = item.categoryname;
                    dto.CategoryID = item.categoryID;
                    dto.CustomerID = item.customerID;
                    dto.ProductID = item.productid;
                    dto.SalesID = item.salesID;
                    dto.SalesPrice = item.salesprice;
                    dto.SalesDate = item.salesdate;
                    dto.SalesAmount = item.salesamount;
                    dto.StockAmount = item.stockamount;
                    dto.isCategoryDeleted = Convert.ToBoolean(item.categoryDeleted);
                    dto.isProductDeleted = Convert.ToBoolean(item.productDeleted);
                    dto.isCustomerDeleted = Convert.ToBoolean(item.customerDeleted);
                    sales.Add(dto);
                }
                return sales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(SALES entity)
        {
            //Manejo de errores
            try
            {
                //Guardar informacion
                db.SALES.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SALES entity)
        {
            try
            {
                SALES sales = db.SALES.First(x => x.ID == entity.ID);
                sales.ProductSalesAmount = entity.ProductSalesAmount;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(SALES entity)
        {
            try
            {

                SALES sales = db.SALES.First(x => x.ID == entity.ID);
                sales.isDeleted = true;
                sales.DeletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            try
            {
                SALES sales = db.SALES.First(x => x.ID == ID);
                sales.isDeleted = false;
                PRODUCT product = new PRODUCT();
                product.ID = ID;
                int temp = product.StockAmount - sales.ProductSalesAmount;
                productDAO.Update(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}