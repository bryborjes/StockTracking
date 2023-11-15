using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL;

namespace StockTracking_Objecs_BryBorj.DAL.DAO
{
    class ProductDAO:StockContext, IDAO<PRODUCT, ProductDetailDTO>
    {

        public List<ProductDetailDTO> Select()
        {
            try
            {
                List<ProductDetailDTO> product = new List<ProductDetailDTO>();
                var list = (from p in db.PRODUCT.Where(x=>x.isDeleted == false)
                            join c in db.CATEGORY 
                            on p.CategoryID equals c.ID
                            select new
                            {
                                productName = p.ProductName,
                                categoryName = c.CategoryName,
                                stockAmount = p.StockAmount,
                                price = p.Price,
                                productID = p.ID,
                                categoryID = c.ID
                            }).OrderBy(x=>x.productName).ToList();
                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CategoryName = item.categoryName;
                    dto.StockAmount = item.stockAmount;
                    dto.Price = item.price;
                    dto.ProductID = item.productID;
                    dto.CategoryID = item.categoryID;
                    product.Add(dto);
                }
                return product;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<ProductDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<ProductDetailDTO> product = new List<ProductDetailDTO>();
                var list = (from p in db.PRODUCT.Where(x=>x.isDeleted == isDeleted)
                            join c in db.CATEGORY 
                            on p.CategoryID equals c.ID
                            select new
                            {
                                productName = p.ProductName,
                                categoryName = c.CategoryName,
                                stockAmount = p.StockAmount,
                                price = p.Price,
                                productID = p.ID,
                                categoryID = c.ID,
                                categoryDeleted = c.isDeleted
                            }).OrderBy(x=>x.productName).ToList();
                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CategoryName = item.categoryName;
                    dto.StockAmount = item.stockAmount;
                    dto.Price = item.price;
                    dto.ProductID = item.productID;
                    dto.CategoryID = item.categoryID;
                    dto.isCategoryDeleted = Convert.ToBoolean(item.categoryDeleted);
                    product.Add(dto);
                }
                return product;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool Insert(PRODUCT entity)
        {
            try
            {
                db.PRODUCT.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool Update(PRODUCT entity)
        {
            try
            {
                PRODUCT product = db.PRODUCT.First(x => x.ID == entity.ID);
                if (entity.CategoryID == 0)
                {
                    product.StockAmount = entity.StockAmount;
                }
                else
                {
                    product.CategoryID = entity.CategoryID;
                    product.ProductName = entity.ProductName;
                    product.Price = entity.Price;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(PRODUCT entity)
        {
            try
            {
                PRODUCT product = db.PRODUCT.First(x => x.ID == entity.ID);
                product.isDeleted = true;
                product.DeletedDate = DateTime.Today;
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
                PRODUCT product = db.PRODUCT.First(x=>x.ID == ID);
                product.isDeleted = false;
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
