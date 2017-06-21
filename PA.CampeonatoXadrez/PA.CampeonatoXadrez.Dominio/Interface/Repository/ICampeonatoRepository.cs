using PA.CampeonatoXadrez.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Dominio.Interface.Repository
{
    public interface ICampeonatoRepository : IDisposable
    {
        List<Campeonato> GetTodos();
        List<Campeonato> Get(Expression<Func<Campeonato, bool>> predicate);
        Campeonato Find(params object[] key);
        Campeonato First(Expression<Func<Campeonato, bool>> predicate);
        void Adicionar(Campeonato entity);
        void Atualizar(Campeonato entity);
        void Deletar(int Id);
        void Commit();
        void Dispose();
    }
}
