using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dataflow.Shared.Models;
using System.Data;

namespace Dataflow.Server.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class LoadData(int year, int month)
    {
        readonly List<PunchDaily> lista = [];
        private readonly string strconn = "Data Source=SERVER-ETIQUETA; Initial Catalog=TIENDA-LABOMBA-SD;User Id=Npino;Password=Jossycar5%;TrustServerCertificate=True;";
        public string errorConn = "";
        public bool errorStatus = false;

        [HttpGet]
        public List<PunchDaily> GetPonchesControlAsistencia() 
        {
            try
            {
                //construir el objeto conexion de SQL a la base de datos.
                using SqlConnection conn = new(strconn);
                //construir el objeto comando SQL.
                SqlCommand comando = new("ReportControlAsistencia", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                comando.Parameters.AddWithValue("@year", year);
                comando.Parameters.AddWithValue("@month", month);
                //Abrir la base de datos.
                conn.Open();
                //Ejecutar el reader que hace la consulta y devuelve un SqlDataReader.
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read()) 
                {
                    //creo una instancia del objeto punchdayly para incluirlo en la lista.
                    PunchDaily ponche = new()
                    {
                        IdUser = reader.GetInt32("IdUser"),
                        Empleado = reader.GetString("empleado"),
                        Fecha = reader.GetDateTime("fecha"),
                        NameDay = reader.GetString("dia"),
                        ShiftId = reader.GetInt32("ShiftId")
                    };
                    lista.Add(ponche);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                errorConn = ex.Message;
                errorStatus = true;
            }
            return lista;
        }
    }
}
