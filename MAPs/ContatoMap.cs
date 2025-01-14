using System.Reflection.Metadata;
using ApiExemploCurso.EDs;
using Dapper.FluentMap.Mapping;

namespace ApiExemploCurso.MAPs
{
    public class ContatoMap: EntityMap<ContatoED>
    {
        public ContatoMap() {
            Map(x => x.Id).ToColumn("ID");
            Map(x => x.Nome).ToColumn("NOME");
            Map(x => x.Email).ToColumn("EMAIL");
            Map(x => x.DtInc).ToColumn("DT_INC");

        }
    }
}
