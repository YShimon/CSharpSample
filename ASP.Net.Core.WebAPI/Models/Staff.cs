using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net.Core.WebAPI.Models
{
    public class Staff
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部署番号
        /// </summary>
        public int DepartmentID { get; set; }

        public IEnumerable<Staff> GetAllStaff()
        {
            return new Staff[] 
            { 
                new Staff{ ID = 0, DepartmentID = 0, Name = "Scotte", },
                new Staff{ ID = 1, DepartmentID = 0, Name = "Tigger", },
                new Staff{ ID = 2, DepartmentID = 1, Name = "Taro", },
            };
        }

        public Staff GetStaff(int id)
        {
            return new Staff { ID = 0, DepartmentID = 0, Name = "Scotte", };
        }
    }
}
