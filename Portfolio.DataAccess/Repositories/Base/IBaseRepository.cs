﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class 
    {
      Task<T?> GetByIdAsync(Guid Id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<bool> SaveAllAsync();

        Task<bool> DeleteAsync(Guid id);
        Task<T> UpdateAsync(T entity);

    }
}
