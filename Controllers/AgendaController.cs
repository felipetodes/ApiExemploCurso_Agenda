using System.Data.SqlClient;
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
        [ProducesResponseType(typeof(List<Contato>), 200)]
        [ProducesResponseType(404)]
        public ActionResult ExecutarSelect() {


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ID, NOME, EMAIL, DT_INC FROM CONTATO";

                con.Open();

                var command = new SqlCommand(sql, con);
                var reader = command.ExecuteReader();
                var lista = new List<Contato>();

                while (reader.Read())
                {
                    lista.Add(
                        new Contato()
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Email = reader.GetString(2),
                            DtInc = reader.GetDateTime(3)

                        }
                        );
            
                }
                lista.Clear();
                con.Close();

                if (lista.Count > 0)
                    return Ok(lista);
                return NotFound("Nenhum contato localizado!");
            }
        }

       
    }
}
