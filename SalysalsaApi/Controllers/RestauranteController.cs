using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalysalsaApi.Controllers
{
    //api/restaurante
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {


        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public RestauranteController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        // GET: api/<RestauranteController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select id,nombre,descripcion
                        from 
                        restaurante
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        // GET api/<RestauranteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestauranteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestauranteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestauranteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
