﻿
namespace _09_01_InterimKantoor
{
    public interface IRepository <TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(object id);
        Task AddAsync(TEntity entity);
        // De methode SearchKlant toevoegen
        Task<IEnumerable<TEntity>> KlantSearch(Expression<Func<TEntity, bool>> zoekwaarde);
        //
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Search();

        //uitbreiding
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> voorwaarden);
        IEnumerable<TEntity> Find(params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>>? voorwaarden,
            params Expression<Func<TEntity, object>>[]? includes);

        void Save();
     }
}