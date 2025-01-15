namespace ApiExemploCurso
{
    public static class Conexao
    {
        private static readonly Dictionary<string , string> conexoes = new Dictionary<string , string>();
        static Conexao()
        {
            conexoes.Add(nameof(AGENDA), "Data Source = localhost; Initial Catalog = AGENDA; Integrated Security:SSPI;");
        }

        /// <summary>
        /// Obtem o valor da string de conexão do banco AGENDA
        /// </summary>

        public static string AGENDA { get => conexoes[nameof(AGENDA)]; }
    }
}
