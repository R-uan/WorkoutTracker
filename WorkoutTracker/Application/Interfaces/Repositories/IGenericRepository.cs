using System;

namespace WorkoutTracker.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
	Task<T> SaveNew(T entity);
	Task<bool> Delete(T entity);
	Task<T?> FindByGuid(Guid id);
}
