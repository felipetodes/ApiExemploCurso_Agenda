using System.Data.SqlClient;
using ApiExemploCurso.EDs;
using Microsoft.AspNetCore.Mvc;

namespace ApiExemploCurso.RNs
{
    public static class ContatoRN
    {
        /// <summary>
        /// Método para listar todos os Contatos
        /// </summary>
        /// <returns></returns>
        public static List<ContatoED> ListarTodos()
        {
                using (var con = new SqlConnection(Conexao.AGENDA))
                {
                    string sql = "SELECT ID, NOME, EMAIL, DT_INC FROM CONTATO";

                    con.Open();

                    var command = new SqlCommand(sql, con);
                    var reader = command.ExecuteReader();
                    var lista = new List<ContatoED>();

                    while (reader.Read())
                    {
                        lista.Add(
                            new ContatoED()
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
        }
    }
}
