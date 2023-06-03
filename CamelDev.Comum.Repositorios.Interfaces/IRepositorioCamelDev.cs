using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Comum.Repositorios.Interfaces
{
    public interface IRepositorioCamelDev <TDominio, TChave> where TDominio : class
    {
        List<TDominio> Selecionar (Expression<Func<TDominio, bool>> where = null);
        TDominio SelecionarPorId(TChave id);
        void Inserir(TDominio dominio);
        void Atualizar(TDominio dominio);
        void Excluir(TDominio dominio);
        void ExcuirPorId(TChave id);

    }
}
