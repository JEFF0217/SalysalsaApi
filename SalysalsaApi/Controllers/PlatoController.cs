using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using SalysalsaApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalysalsaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoController : ControllerBase
    {



        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public PlatoController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // GET: api/<platoController>
        [HttpGet]
         public JsonResult Get()
        {
            string query = @"
                        select *
                        from 
                        plato
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


        // GET: api/<platoController>/id
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                        select *
                        from 
                        plato
                        where id=@plato_id;
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@plato_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        //ELIMINACION
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from plato 
                        where id=@plato_id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@plato_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        //ACTUALIZACIÓN


        [HttpPut]
        public JsonResult Put(Plato plato)
        {
            string query = @"
                        update plato set 
                        titulo =@PlatoTitulo,
                        descripcion =@PlatoDescripcion,
                        precio=@PlatoPrecio,
                        restaurante_id =@PlatoRestaurante_id,
                        img =@Plato_img  
                        where id =@PlatoId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@PlatoId", plato.id);
                    myCommand.Parameters.AddWithValue("@PlatoTitulo", plato.titulo);
                    myCommand.Parameters.AddWithValue("@PlatoDescripcion", plato.descripcion);
                    myCommand.Parameters.AddWithValue("@PlatoPrecio", plato.precio);
                    myCommand.Parameters.AddWithValue("@PlatoRestaurante_id", plato.restaurante_id);
                    myCommand.Parameters.AddWithValue("@Plato_img", plato.img);
                    

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }
        //CREACIÓN

        [HttpPost]
        public JsonResult Post(Plato plato)
        {
            string query = @"
                        insert into plato 
                        (titulo,descripcion,precio,restaurante_id,img) 
                        values
                         (@PlatoTitulo,@PlatoDescripcion,@PlatoPrecio,@PlatoRestaurante_id,@Plato_img);
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@PlatoTitulo", plato.titulo);
                    myCommand.Parameters.AddWithValue("@PlatoDescripcion", plato.descripcion);
                    myCommand.Parameters.AddWithValue("@PlatoPrecio", plato.precio);
                    myCommand.Parameters.AddWithValue("@PlatoRestaurante_id", plato.restaurante_id);
                    myCommand.Parameters.AddWithValue("@Plato_img", plato.img);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
    }
}
