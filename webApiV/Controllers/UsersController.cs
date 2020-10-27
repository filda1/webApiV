using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;


// Install   Data.Mysql  y  Dapper  ======> https://www.youtube.com/watch?v=e5unmvq9Q1E

namespace webApiV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        string connection = "Server=165.22.197.228;Port=3306;User=myuser;Password={Mm<ΚkWn{]^skzoNuws~x;DataBase=dev_vivleo";

        [HttpGet]
        public ActionResult Get()
        {
          

            IEnumerable<Models.User> lst = null;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "select id, username from users";
                lst = db.Query<Models.User>(sql);
            }

            return Ok(lst);

        }



        [HttpPost]
        public ActionResult Insert(Models.User model)
        {

            int result = 0;
         
            using (var db = new MySqlConnection(connection))
            {
                var sql = "insert into to users(username, password)"+
                          " values(@username, @password)";

                result = db.Execute(sql, model);
            }

            return Ok(result);

        }



        [HttpPut]
        public ActionResult Edit(Models.User model)
        {

            int result = 0;
       
            using (var db = new MySqlConnection(connection))
            {
                var sql = "UPDATE Users set username=@username, password=@password" +
                          "where id=@id";

                result = db.Execute(sql, model);
            }

            return Ok(result);

        }


        [HttpDelete]
        public ActionResult Delete(Models.User model)
        {

            int result = 0;

            using (var db = new MySqlConnection(connection))
            {
                var sql = "delete from Users where id=@i";

                result = db.Execute(sql, model);
            }

            return Ok(result);

        }
    }
}
