using Microsoft.AspNetCore.Http;
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

namespace SalysalsaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ServicioController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // GET: api/<servicioController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select *
                        from 
                        servicio
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


        // GET: api/<servicioController>/id
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                        select *
                        from 
                        servicio
                        where id=@servicio_id;
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@servicio_id", id);
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
                        delete from servicio 
                        where id=@servicio_id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@servicio_id", id);

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
        public JsonResult Put(Servicio servicio)
        {
            string query = @"
                        update servicio set 
                        titulo =@servicioTitulo,
                        descripcion =@servicioDescripcion,
                        restaurante_id =@servicioRestaurante_id,
                        img =@servicio_img  
                        where id =@servicioId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@servicioId", servicio.id);
                    myCommand.Parameters.AddWithValue("@servicioTitulo", servicio.titulo);
                    myCommand.Parameters.AddWithValue("@servicioDescripcion", servicio.descripcion);
                    myCommand.Parameters.AddWithValue("@servicioRestaurante_id", servicio.restaurante_id);
                    myCommand.Parameters.AddWithValue("@servicio_img", servicio.img);


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
        public JsonResult Post(Servicio servicio)
        {
            string query = @"
                        insert into servicio 
                        (titulo,descripcion,restaurante_id,img) 
                        values
                         (@servicioTitulo,@servicioDescripcion,@servicioRestaurante_id,@servicio_img);
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("salysalsadb");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@servicioTitulo", servicio.titulo);
                    myCommand.Parameters.AddWithValue("@servicioDescripcion", servicio.descripcion);
                    myCommand.Parameters.AddWithValue("@servicioRestaurante_id", servicio.restaurante_id);
                    myCommand.Parameters.AddWithValue("@servicio_img", servicio.img);

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
