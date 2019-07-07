using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Infrastructure.Database
{
    internal abstract class RepositoryEntity<TEntity, TDataRow> : IRepository<TEntity>
        where TDataRow : DefaultDataRow
        where TEntity : class
    {
        protected readonly DataBaseContext DataBaseContext;
        protected readonly IDataMapper<TEntity, TDataRow> DataMapper;
        protected readonly DbSet<TDataRow> DbSet;


        protected RepositoryEntity(DataBaseContext dataBaseContext, IDataMapper<TEntity, TDataRow> dataMapper)
        {
            DataBaseContext = dataBaseContext;
            DataMapper = dataMapper;

            DbSet = DataBaseContext.Set<TDataRow>();
        }

        public void Store(TEntity entity)
        {
            DbSet.Add(DataMapper.ToRow(entity));
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(DataMapper.ToRow(entity));
        }

        public TEntity GetById(Guid id)
        {
            var dataRow = DbSet.FirstOrDefault(row => row.Id == id);

            return dataRow != null ? DataMapper.ToEntity(dataRow) : null;
        }

        public IList<TEntity> GetAll()
        {
            return ToList(DbSet.ToList());
        }

        public bool HasById(Guid id)
        {
            return DbSet.Any(row => row.Id == id);
        }

        private List<TEntity> ToList(IEnumerable<TDataRow> dataRows)
        {
            return dataRows.Select(dataRow => DataMapper.ToEntity(dataRow)).ToList();
        }
    }
}