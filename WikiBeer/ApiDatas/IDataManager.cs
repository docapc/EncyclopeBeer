﻿namespace Ipme.WikiBeer.ApiDatas
{
    public interface IDataManager<TModel, TDto>
        where TModel : class
        where TDto : class
    {
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(Guid id);
        Task<TModel> Add(TModel model);
        Task<TModel> Update(Guid id, TModel model);
        Task DeleteById(Guid id);
    }
}