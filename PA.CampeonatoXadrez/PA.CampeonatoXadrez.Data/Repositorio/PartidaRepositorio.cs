using PA.CampeonatoXadrez.Data.Contexto;
using PA.CampeonatoXadrez.Dominio.Entidades;
using PA.CampeonatoXadrez.Dominio.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Data.Repositorio
{
   public  class PartidaRepositorio : IPartidaRepository
    {
       private readonly CampeonatoXadrezContexto _db;

       public PartidaRepositorio() 
        {
            _db = new CampeonatoXadrezContexto();
        }
       public List<Partida> GetTodos()
       {
           return _db.Partidas.ToList();
       }
       public List<Partida> Get(Expression<Func<Partida, bool>> predicate)
       {
           return _db.Partidas.Include("Jogador2").Include("Jogador1").Where(predicate).ToList();
       }
       public Partida Find(params object[] key)
       {
           return _db.Partidas.Find(key);
       }
       public Partida First(Expression<Func<Partida, bool>> predicate)
       {
           return _db.Partidas.Where(predicate).FirstOrDefault();
       }
       public void Adicionar(Partida partida)
       {
           _db.Partidas.Add(partida);
           Commit();
       }
       public void Atualizar(Partida partida)
       {
           _db.Entry(partida).State = System.Data.Entity.EntityState.Modified;
           Commit();
       }
       public void Deletar(int idPartida)
       {
           var partida = _db.Jogadors.Find(idPartida);
           _db.Jogadors.Remove(partida);
           Commit();
       }

       public void Commit()
       {
           _db.SaveChanges();
       }
       public void Dispose()
       {
           if (_db != null)
           {
               _db.Dispose();
           }
           GC.SuppressFinalize(this);
       }
    }
}
