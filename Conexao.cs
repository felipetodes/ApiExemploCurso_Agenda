namespace ApiExemploCurso
{
    public static class Conexao
    {
        private static readonly Dictionary<string , string> conexoes = new Dictionary<string , string>();
        static Conexao()
        {
            
        }

        public static  string AGENDA { get; set; }
    }
}
