using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL;
using StockTracking_Objecs_BryBorj.DAL.DAO;


namespace StockTracking_Objecs_BryBorj.BLL
{
    class UserBLL:IBLL<UserDetailDTO,UserDTO>
    {
        UserDAO dao = new UserDAO();

        public bool Insert(UserDetailDTO entity)
        {
            USER users = new USER();
            users.UserName = entity.UserName;
            users.Password = entity.Password;
            users.Name = entity.Name;
            users.Surname = entity.Surname;
            users.AccerLevel = entity.AccesLevel; 
            users.PhotographyPth = entity.PhotographyPth;
            dao.Insert(users);
            return true;
        }

        public bool Update(UserDetailDTO entity)
        {
            USER user = new USER();
            user.ID = entity.ID;
            user.UserName = entity.UserName;
            user.Password = entity.Password;
            user.Name = entity.Name;
            user.Surname = entity.Surname;
            user.AccerLevel = entity.AccesLevel;
            user.PhotographyPth = entity.PhotographyPth;
            return dao.Update(user);
        }

        public bool Delete(UserDetailDTO entity)
        {
            USER user = new USER();
            user.ID = entity.ID;
            dao.Delete(user);
            return true;
        }

        public UserDTO Select()
        {
            UserDTO dto = new UserDTO();
            dto.Users = dao.Select();
            return dto; 
        }

        public bool GetBack(UserDetailDTO entity)
        {
            return dao.GetBack(entity.ID);
        }
    }
}
