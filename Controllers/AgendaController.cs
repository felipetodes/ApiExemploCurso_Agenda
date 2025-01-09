using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace ApiExemploCurso.Controllers
{
    [ApiController]
    [Route("Agenda")]

    public class AgendaController : Controller
    {
        private readonly string _connectionString;
        private object console;

        public AgendaController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MinhaConexao");
        }

        public object JSON { get; private set; }

        [HttpGet]
        [Route("ExecutarSelect")]
        [ProducesResponseType(typeof(List<Contato>), 200)]
        [ProducesResponseType(404)]
        public ActionResult ExecutarSelect()
        {


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

                con.Close();

                if (lista.Count > 0)
                    return Ok(lista);
                return NotFound("Nenhum contato localizado!");
            }

        }

        [HttpPost]
        [Route("ExecutarInsert")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult ExecutarInsert([FromBody] Contato contato)
        {


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO CONTATO (NOME, EMAIL, DT_INC) VALUES(@Nome, @Email, GETDATE())";


                con.Open();

                var command = new SqlCommand(sql, con);

                command.Parameters.AddWithValue("@Nome", contato.Nome);
                command.Parameters.AddWithValue("@Email", contato.Email);

                var qtdLinhasAfetadas = command.ExecuteNonQuery();

                con.Close();


                if (qtdLinhasAfetadas > 0)
                    return Ok("Contato inserido com sucesso!");
                return BadRequest("Ocorreu um erro ao incluir o novo contato");
            }

        }
        [HttpPut]
        [Route("ExecutarUpdate")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult ExecutarUpdate([FromBody] Contato contato)
        {


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE CONTATO SET NOME = @Nome, EMAIL = @Email WHERE ID = @Id";


                con.Open();

                var command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@Id", contato.Id);
                command.Parameters.AddWithValue("@Nome", contato.Nome);
                command.Parameters.AddWithValue("@Email", contato.Email);

                var qtdLinhasAfetadas = command.ExecuteNonQuery();

                con.Close();


                if (qtdLinhasAfetadas > 0)
                    return Ok("Contato atualizado com sucesso!");
                return BadRequest("Ocorreu um erro ao atualizar o novo contato");
            }

        }
        [HttpDelete]
        [Route("ExecutarDelete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult ExecutarDelete(int id)
        {

            try
            {

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM CONTATO WHERE ID = @id";


                    con.Open();

                    var command = new SqlCommand(sql, con);
                    command.Parameters.AddWithValue("@id", id);


                    var qtdLinhasAfetadas = command.ExecuteNonQuery();

                    con.Close();


                    if (qtdLinhasAfetadas > 0)
                        return Ok("Contato excluído com sucesso!");
                        return NotFound("Nenhum contato localizado para exclusão!");


                }
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir o contato");


            }
        }
    }
}
