using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockTracking_Objecs_BryBorj.DAL.DTO
{
    public class UserDetailDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AccesLevel { get; set; }
        public string PhotographyPth { get; set; }
    }
}
