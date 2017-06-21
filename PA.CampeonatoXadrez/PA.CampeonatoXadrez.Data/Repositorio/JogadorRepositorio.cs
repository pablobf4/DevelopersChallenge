using PA.CampeonatoXadrez.Data.Contexto;
using PA.CampeonatoXadrez.Dominio.Entidades;
using PA.CampeonatoXadrez.Dominio.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Data.Repositorio
{
    public class JogadorRepositorio : IJogadorRepository
    {
        private readonly CampeonatoXadrezContexto _db;
        
        public JogadorRepositorio()
        {
            _db = new CampeonatoXadrezContexto();
        }
        //public List<Jogador> CombinacaoAleatoria()
        //{

         
         
        ////  var listaAleatoria = SELECT * from Jogadors A1 , Jogadors A2,
        ////      Where A1
        //}
        public List<Jogador> GetTodos()
        {
            return _db.Jogadors.ToList();
        }
        public List<Jogador> Get(Expression<Func<Jogador, bool>> predicate)
        {
            return _db.Jogadors.Where(predicate).ToList();
        }
        public Jogador Find(params object[] key)
        {
            return _db.Jogadors.Find(key);
        }
        public Jogador First(Expression<Func<Jogador, bool>> predicate)
        {
            return _db.Jogadors.Where(predicate).FirstOrDefault();
        }
        public void Adicionar(Jogador jogador)
        {
            _db.Jogadors.Add(jogador);
            Commit();
        }
        public void Atualizar(Jogador jogador)
        {
            _db.Entry(jogador).State = System.Data.Entity.EntityState.Modified;
            Commit();
        }
        public void Deletar(int idJogador)
        {
            var aluno = _db.Jogadors.Find(idJogador);
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
