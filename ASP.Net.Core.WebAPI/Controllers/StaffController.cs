using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ASP.Net.Core.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ASP.Net.Core.WebAPI.Controllers
{
    [ApiController]
    public class StaffController : ControllerBase
    {
        // -------------------------------------------------
        // Get ⇒ Readを表す(リソースを取得する場合に使用します)
        // -------------------------------------------------

        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Staff> GetAllStaff()
        {
            return new Staff().GetAllStaff();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Staff GetStaff(int id)
        {
            return new Staff().GetStaff(id);
        }

        // -------------------------------------------------
        // Post ⇒ Createを表す(IDが自明でない場合に使用します)
        // -------------------------------------------------

        [HttpPost]
        [Route("api/[controller]")]
        public Staff AddStaff()
        {
            return new Staff { ID = 10, DepartmentID = 10, Name = "HOGE" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departmentID"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        /// <example>
        /// 入力：パラメータ複数 + json
        /// [input json]
        ///     {
        ///         "Name" : "Hanako"
        ///     }
        /// </example>
        [HttpPost]
        [Route("api/[controller]/{id}/{departmentID}")]
        public Staff FillStaff(int id, int departmentID, Staff staff)
        {
            return new Staff { ID = id, DepartmentID = departmentID, Name = staff.Name };
        }

        // -------------------------------------------------
        // PUT ⇒ Create/Replaceを表します
        // -------------------------------------------------

        // -------------------------------------------------
        // DELETE ⇒ リソースの削除を行う場合に使用します
        // -------------------------------------------------
    }
}