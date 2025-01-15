using System.Data.SqlClient;
using ApiExemploCurso.EDs;
using Dapper;
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
                con.Open();
                string sql = "SELECT ID, NOME, EMAIL, DT_INC FROM CONTATO";

                   return con.Query<ContatoED>(sql).ToList();
                

                }

            }
        }
    }

