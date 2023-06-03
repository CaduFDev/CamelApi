using CamelDev.CamelApi.DAO.Context;
using CamelDev.CamelApi.Domain_;
using CamelDev.Comum.Repositorio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.CamelApi.Repositorios.Ef
{
    public class RepositorioAlunos : RepositorioCamelDev<Aluno, int> 
    {
        public RepositorioAlunos(CamelApiDbContext contextApi) : base(contextApi)
        {
            
        }
    }
}
