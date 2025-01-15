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
        public static ContatoED? ConsultaPorId(int id)
        {
            using (var con = new SqlConnection(Conexao.AGENDA))
            {
                con.Open();
                string sql = "SELECT* FROM CONTATO WHERE ID = @id";

                return con.Query<ContatoED>(sql, new { id }).FirstOrDefault();


            }

        }
        public static int Inserir(ContatoED contato)
        {
            using (var con = new SqlConnection(Conexao.AGENDA))
            {
                con.Open();
                string sql = "INSERT INTO CONTATO (NOME, EMAIL, DT_INC) VALUES(@Nome, @Email, GETDATE())";

                return con.Execute(sql, contato);


            }

        }
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

