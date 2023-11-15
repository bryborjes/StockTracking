using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;

namespace StockTracking_Objecs_BryBorj.DAL.DAO
{
    class CategoryDAO:StockContext, IDAO<CATEGORY, CategoryDetailDTO>
    {

        public List<CategoryDetailDTO> Select()
        {
            List<CategoryDetailDTO> categories = new List<CategoryDetailDTO>();//Genrar objeto de listado de categorías
            var list = db.CATEGORY.Where(x => x.isDeleted == false); ;//Insertar tabla de categorias a lista
            foreach (var item in list)//Recorrer la tabla
            {
		        CategoryDetailDTO dto = new CategoryDetailDTO();//Instanciar lista
                dto.ID = item.ID;
                dto.CategoryName = item.CategoryName;
                categories.Add(dto);//Agrgar categorias
            }
            return categories;//Retornar tabla
        }

        public List<CategoryDetailDTO> Select(bool isDeleted)
        {
            List<CategoryDetailDTO> categories = new List<CategoryDetailDTO>();//Genrar objeto de listado de categorías
            var list = db.CATEGORY.Where(x => x.isDeleted == isDeleted); ;//Insertar tabla de categorias a lista
            foreach (var item in list)//Recorrer la tabla
            {
                CategoryDetailDTO dto = new CategoryDetailDTO();//Instanciar lista
                dto.ID = item.ID;
                dto.CategoryName = item.CategoryName;
                categories.Add(dto);//Agrgar categorias
            }
            return categories;//Retornar tabla
        }

        public bool Insert(CATEGORY entity)
        {
            try//Exepcion de errores
            {//Agrgar entidades
                db.CATEGORY.Add(entity);
                db.SaveChanges();//Guardar cambios
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }



        public bool Update(CATEGORY entity)
        {
            try
            {
                CATEGORY category = db.CATEGORY.First(X => X.ID == entity.ID);
                category.CategoryName = entity.CategoryName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(CATEGORY entity)
        {
            try
            {
                CATEGORY category = db.CATEGORY.First(x => x.ID == entity.ID);
                category.isDeleted = true;
                category.DeletedDate = DateTime.Today;
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
                CATEGORY category = db.CATEGORY.First(x => x.ID == ID);
                category.isDeleted = false;
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
