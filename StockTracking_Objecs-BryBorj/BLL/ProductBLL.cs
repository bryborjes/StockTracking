using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL;
using StockTracking_Objecs_BryBorj.DAL.DAO;

namespace StockTracking_Objecs_BryBorj.BLL
{
    class ProductBLL:IBLL<ProductDetailDTO, ProductDTO>
    {
        CategoryDAO category = new CategoryDAO();
        ProductDAO dao = new ProductDAO();

        public bool Insert(ProductDetailDTO entity)
        {
            //Inserta los datos del producto a la base de datos
            PRODUCT product = new PRODUCT();
            product.ProductName = entity.ProductName;
            product.CategoryID = entity.CategoryID;
            product.Price = Convert.ToSingle(entity.Price);
            return dao.Insert(product);
        }

        public bool Update(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.ProductName = entity.ProductName;
            product.StockAmount = entity.StockAmount;
            product.Price = entity.Price;
            product.CategoryID = entity.CategoryID;
            return dao.Update(product);
        }
        public bool Delete(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            dao.Delete(product);
            return true;
        }

        public ProductDTO Select()
        {
            ProductDTO dto = new ProductDTO();
            dto.Categories = category.Select();
            dto.Products = dao.Select();
            return dto;
        }

        public bool GetBack(ProductDetailDTO entity)
        {
            return dao.GetBack(entity.ProductID);
        }
    }
}
