namespace VouDeVan.Infrastructure.Database
{
    public interface IDataMapper<TEntity, TDataRow>
    {
        TEntity ToEntity(TDataRow dataRow);

        TDataRow ToRow(TEntity entity);
    }
}