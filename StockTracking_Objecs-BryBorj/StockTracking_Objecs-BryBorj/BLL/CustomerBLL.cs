using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL.DAO;

namespace StockTracking_Objecs_BryBorj.BLL
{
    class CustomerBLL:IBLL<CustomerDetailDTO, CustomerDTO>
    {
        CustomerDAO dao = new CustomerDAO();
        public bool Insert(CustomerDetailDTO entity)
        {
            CUSTOMERS customer = new CUSTOMERS();
            customer.CustomerName = entity.CustomerName;
            return dao.Insert(customer);
        }

        public bool Update(CustomerDetailDTO entity)
        {
            CUSTOMERS customer = new CUSTOMERS();
            customer.CustomerName = entity.CustomerName;
            customer.ID = entity.ID;
            return dao.Update(customer);
        }

        public bool Delete(CustomerDetailDTO entity)
        {
            CUSTOMERS customer = new CUSTOMERS();
            customer.ID = entity.ID;
            dao.Delete(customer);
            return true;
        }

        public CustomerDTO Select()
        {
            CustomerDTO dto = new CustomerDTO();
            dto.Customer = dao.Select();
            return dto;
            
        }

        public bool GetBack(CustomerDetailDTO entity)
        {
            return dao.GetBack(entity.ID);
        }
    }
}
