using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL;
using StockTracking_Objecs_BryBorj.DAL.DAO;

namespace StockTracking_Objecs_BryBorj.BLL
{
    class CategoryBLL:IBLL<CategoryDetailDTO, CategoryDTO>
    {
        CategoryDAO dao = new CategoryDAO();
        public bool Insert(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY();
            category.CategoryName = entity.CategoryName;
            return dao.Insert(category);
        }

        public bool Update(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY();
            category.CategoryName = entity.CategoryName;
            category.ID = entity.ID;
            return dao.Update(category);
        }

        public bool Delete(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY();
            category.ID = entity.ID;
            dao.Delete(category);
            return true;
        }

        public CategoryDTO Select()
        {
            CategoryDTO dto = new CategoryDTO();
            dto.Categories = dao.Select();
            return dto;
        }

        public bool GetBack(CategoryDetailDTO entity)
        {
            return dao.GetBack(entity.ID);
        }
    }
}
