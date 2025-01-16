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


            try
            {
                var qtdLinhas = ContatoRN.Alterar(contato);
                if (qtdLinhas > 0)
                    return Ok("Contato alterado com sucesso!");
                return BadRequest("Ocorreu um erro ao alterar um novo contato!");
            }
            catch (Exception)
            {

                return BadRequest("Ocorreu um erro ao comunicar com o banco de dados!");
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
                var qtdLinhas = ContatoRN.Excluir(id);
                if (qtdLinhas > 0)
                    return Ok("Contato excluído com sucesso!");
                return BadRequest("Ocorreu um erro ao excluir um novo contato!");
            }
            catch (Exception)
            {

                return BadRequest("Ocorreu um erro ao comunicar com o banco de dados!");
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
  
