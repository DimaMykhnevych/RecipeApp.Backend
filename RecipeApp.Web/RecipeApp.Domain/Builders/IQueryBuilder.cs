namespace RecipeApp.Domain.Builders
{
    public interface IQueryBuilder<TEntity>
    {
        IQueryable<TEntity> Build();
    }
}
