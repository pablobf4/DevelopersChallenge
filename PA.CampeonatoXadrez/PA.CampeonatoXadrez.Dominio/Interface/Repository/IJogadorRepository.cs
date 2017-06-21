using PA.CampeonatoXadrez.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Dominio.Interface.Repository
{
    public interface IJogadorRepository : IDisposable
    {
       // List<Jogador> CombinacaoAleatoria();
        List<Jogador> GetTodos();
        List<Jogador> Get(Expression<Func<Jogador, bool>> predicate);
        Jogador Find(params object[] key);
        Jogador First(Expression<Func<Jogador, bool>> predicate);
        void Adicionar(Jogador entity);
        void Atualizar(Jogador entity);
        void Deletar(int Id);
        void Commit();
        void Dispose();
    }
    
}
