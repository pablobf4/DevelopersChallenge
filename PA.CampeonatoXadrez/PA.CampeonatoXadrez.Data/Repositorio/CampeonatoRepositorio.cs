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
    public class CampeonatoRepositorio : ICampeonatoRepository
    {
        private readonly CampeonatoXadrezContexto _db;

        public CampeonatoRepositorio() 
        {
            _db = new CampeonatoXadrezContexto();
        }
        public List<Campeonato> GetTodos()
        {
            return _db.Campeonatos.ToList();
        }
        public List<Campeonato> Get(Expression<Func<Campeonato, bool>> predicate)
        {
            return _db.Campeonatos.Where(predicate).ToList();
        }
        public Campeonato Find(params object[] key)
        {
            return _db.Campeonatos.Find(key);
        }
        public Campeonato First(Expression<Func<Campeonato, bool>> predicate)
        {
            return _db.Campeonatos.Where(predicate).FirstOrDefault();
        }
        public void Adicionar(Campeonato campeonato)
        {
            _db.Campeonatos.Add(campeonato);
            Commit();
        }
        public void Atualizar(Campeonato campeonato)
        {
            _db.Entry(campeonato).State = System.Data.Entity.EntityState.Modified;
            Commit();
        }
        public void Deletar(int idcampeonato)
        {
            var aluno = _db.Jogadors.Find(idcampeonato);
            _db.Jogadors.Remove(aluno);
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
