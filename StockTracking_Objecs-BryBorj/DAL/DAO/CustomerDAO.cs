using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;

namespace StockTracking_Objecs_BryBorj.DAL.DAO
{
    class CustomerDAO:StockContext, IDAO<CUSTOMERS, CustomerDetailDTO>
    {
        public List<CustomerDetailDTO> Select()
        {
            List<CustomerDetailDTO> customer = new List<CustomerDetailDTO>();//Instanciar lista nueva
            var list = db.CUSTOMERS.Where(x => x.idDeleted == false); ;//Agregar tabla a lista
            foreach (var item in list)//Recorer lista
            {
                CustomerDetailDTO dto = new CustomerDetailDTO();//Instanciar lista
                dto.ID = item.ID;//agregar identificador
                dto.CustomerName = item.CustomerName;//Agragar nombre de cliente
                customer.Add(dto);//Agragar cambios a lista
            }
            return customer;//Retornar lista
        }

        public List<CustomerDetailDTO> Select(bool isDeleted)
        {
            List<CustomerDetailDTO> customer = new List<CustomerDetailDTO>();//Instanciar lista nueva
            var list = db.CUSTOMERS.Where(x=>x.idDeleted == isDeleted);//Agregar tabla a lista
            foreach (var item in list)//Recorer lista
            {
                CustomerDetailDTO dto = new CustomerDetailDTO();//Instanciar lista
                dto.ID = item.ID;//agregar identificador
                dto.CustomerName = item.CustomerName;//Agragar nombre de cliente
                customer.Add(dto);//Agragar cambios a lista
            }
            return customer;//Retornar lista
        }

        public bool Insert(CUSTOMERS entity)
        {
            try//Exepcion de errores
            {
                db.CUSTOMERS.Add(entity);//Agrgar entidades
                db.SaveChanges();//Guardar cambios
                return true;//Retornar verdadero
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool Update(CUSTOMERS entity)
        {
            try
            {
                CUSTOMERS customer = db.CUSTOMERS.First(X => X.ID == entity.ID);
                customer.CustomerName = entity.CustomerName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(CUSTOMERS entity)
        {
            try
            {
                CUSTOMERS customer = db.CUSTOMERS.First(x => x.ID == entity.ID);
                customer.idDeleted = true;
                customer.DeletedDate = DateTime.Today;
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
                CUSTOMERS customer = db.CUSTOMERS.First(x => x.ID == ID);
                customer.idDeleted = false;
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
