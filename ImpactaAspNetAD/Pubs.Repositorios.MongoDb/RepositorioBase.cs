using Pubs.Dominio;
using MongoDB.Driver;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace Pubs.Repositorios.MongoDb
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        private readonly IMongoDatabase _db;

        public RepositorioBase()
        {
            _db = new MongoClient().GetDatabase("Pubs");
        }

        public void Inserir(T entidade)
        {
            _db.GetCollection<T>(typeof(T).Name).InsertOne(entidade);
        }

        public List<T> Selecionar()
        {
            return _db.GetCollection<T>(typeof(T).Name).AsQueryable().ToList();
        }

        public T Selecionar(Guid guid)
        {
            return _db.GetCollection<T>(typeof(T).Name).Find(p => p.Id == guid).SingleOrDefault();
        }

        public List<T> Selecionar(Expression<Func<T, bool>> query)
        {
            return _db.GetCollection<T>(typeof(T).Name).Find(query).ToList();
        }

        public void Atualizar(T entidade)
        {
            _db.GetCollection<T>(typeof(T).Name).ReplaceOne(e => e.Id == entidade.Id, entidade);
        }

        public void Excluir(Guid id)
        {
            _db.GetCollection<T>(typeof(T).Name).DeleteOne(e => e.Id == id);
        }
    }
}