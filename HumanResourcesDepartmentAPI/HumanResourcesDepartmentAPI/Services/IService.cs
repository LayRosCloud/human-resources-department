namespace HumanResourcesDepartmentAPI.Services
{
    public interface IService<TSource, VKey>
    {
        Task<List<TSource>> FindAll();
        Task<TSource> Find(VKey id);
        Task<TSource> Create(TSource item);
        Task<TSource> Update(TSource item);
        Task<TSource> Delete(VKey id);
    }
}
