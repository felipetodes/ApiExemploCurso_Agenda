using System.Data.SqlClient;
using ApiExemploCurso.EDs;
using Dapper;


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
                string sql = "SELECT* FROM CONTATO";

                   return con.Query<ContatoED>(sql).ToList();
                

                }

            }

        /// <summary>
        /// Exclusão de Contatos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ContatoED? ConsultarPorId(int id)
        {
            using (var con = new SqlConnection(Conexao.AGENDA))
            {
                con.Open();
                string sql = "SELECT* FROM CONTATO WHERE ID = @id";

                return con.Query<ContatoED>(sql, new { id }).FirstOrDefault();


            }

        }

        /// <summary>
        /// Inclusão de Novos Contatos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Inserir(ContatoED contato)
        {
            using (var con = new SqlConnection(Conexao.AGENDA))
            {
                con.Open();
                string sql = "INSERT INTO CONTATO (NOME, EMAIL, DT_INC) VALUES(@Nome, @Email, GETDATE())";

                return con.Execute(sql, contato);


            }

        }

        /// <summary>
        /// Alteração de Contatos Existentes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Alterar(ContatoED contato)
        {
            using (var con = new SqlConnection(Conexao.AGENDA))
            {
                con.Open();
                string sql = "UPDATE CONTATO SET NOME = @Nome, EMAIL = @Email WHERE ID = @Id";

                return con.Execute(sql, contato);


            }

        }


        public static int Excluir(int id)
        {
            using (var con = new SqlConnection(Conexao.AGENDA))
            {
                con.Open();
                string sql = "DELETE FROM CONTATO WHERE ID = @id";

                return con.Execute(sql, id);


            }

        }
    }
    }

