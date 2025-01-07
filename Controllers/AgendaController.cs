using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiExemploCurso.Controllers
{
    [ApiController]
    [Route("Agenda")]

    public class AgendaController : Controller
    {
        private readonly string _connectionString;

        public AgendaController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MinhaConexao");
        }

        [HttpGet]
        [Route("ExecutarSelect")]
        public ActionResult ExecutarSelect() {


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ID, NOME, EMAIL, DT_INC FROM CONTATO";

                con.Open();

                var command = new SqlCommand(sql, con);
                var reader = command.ExecuteReader();
                var lista = new List<Contato>();
            }
        }

       
    }
}
