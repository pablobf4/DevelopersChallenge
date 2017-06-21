using PA.CampeonatoXadrez.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Dominio.Interface.Repository
{
   public interface IPartidaRepository : IDisposable
    {
           List<Partida> GetTodos();
           List<Partida> Get(Expression<Func<Partida, bool>> predicate);
           Partida Find(params object[] key);
           Partida First(Expression<Func<Partida, bool>> predicate);
           void Adicionar(Partida entity);
           void Atualizar(Partida entity);
           void Deletar(int Id);
           void Commit();
           void Dispose();
    }
}
