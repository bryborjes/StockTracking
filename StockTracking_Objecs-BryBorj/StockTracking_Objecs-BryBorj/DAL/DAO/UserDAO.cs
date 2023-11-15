using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL;

namespace StockTracking_Objecs_BryBorj.DAL.DAO
{
    class UserDAO:StockContext, IDAO<USER, UserDetailDTO>
    {
        public List<UserDetailDTO> Select()
        {
            try
            {
                List<UserDetailDTO> users = new List<UserDetailDTO>();
                var list = db.USER;
                foreach (var item in list) //Recorrido
                {
                    UserDetailDTO dto = new UserDetailDTO();  
                    dto.ID = item.ID;
                    dto.UserName = item.UserName;
                    dto.Password = item.Password;
                    dto.Name = item.Name;
                    dto.Surname = item.Surname;
                    dto.AccesLevel = Convert.ToString(item.AccerLevel);
                    dto.PhotographyPth = item.PhotographyPth;
                    users.Add(dto);
                }
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(USER entity)
        {
            try
            {
                db.USER.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(USER entity)
        {
            try
            {
                USER user = db.USER.First(x => x.ID == entity.ID);
                user.ID = entity.ID;
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.UserName = entity.UserName;
                user.Password = entity.Password;
                user.PhotographyPth = entity.PhotographyPth;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(USER entity)
        {
            try
            {
                USER user = db.USER.First(x => x.ID == entity.ID);
                db.USER.Remove(user);
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
            throw new NotImplementedException();
        }
    }
}
