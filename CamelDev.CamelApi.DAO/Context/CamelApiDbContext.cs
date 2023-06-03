using CamelDev.CamelApi.Domain_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.CamelApi.DAO.Context
{
    public class CamelApiDbContext:DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public CamelApiDbContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
