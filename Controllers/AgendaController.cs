using System.Data.SqlClient;
using ApiExemploCurso.EDs;
using ApiExemploCurso.RNs;
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
        [ProducesResponseType(typeof(List<ContatoED>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult ExecutarSelect()
        {
            try
            {
                var lista = ContatoRN.ListarTodos();
                if (lista.Count > 0)
                    return Ok(lista);
                return NotFound("Nenhum contato localizado!");
            }
            catch (Exception)
            {

                return BadRequest("Ocorreu um erro ao comunicar com o banco de dados!");
            }
               
            }
        [HttpPost]
        [Route("ExecutarInsert")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult ExecutarInsert([FromBody] ContatoED contato)
        {

            {
                try
                {
                    var qtdLinhas = ContatoRN.Inserir(contato);
                    if (qtdLinhas > 0)
                        return Ok("Contato incluído com sucesso!");
                    return BadRequest("Ocorreu um erro ao incluir um novo contato!");
                }
                catch (Exception)
                {

                    return BadRequest("Ocorreu um erro ao comunicar com o banco de dados!");
                }

            }
            [HttpPut]
        [Route("ExecutarUpdate")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult ExecutarUpdate([FromBody] ContatoED contato)
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

        [HttpGet]
        [Route("ExecutarSelectEspecifico")]
        [ProducesResponseType(typeof(ContatoED), 200)]
        [ProducesResponseType(404)]
        public ActionResult ExecutarSelectEspecifico(int id)
        {
            try
            {
                var contato = ContatoRN.ConsultarPorId(id);
                if (contato != null)
                    return Ok(contato);
                return NotFound("Nenhum contato localizado com o ID fornecido!");
            }
            catch (Exception)
            {

                return BadRequest("Ocorreu um erro ao comunicar com o banco de dados!");
            }

        }

    }
        }
  
