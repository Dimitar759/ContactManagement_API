﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll(); 
        Task<T?> GetById(int id); 
        Task Add(T entity); 
        Task Update(T entity); 
        Task Delete(T entity);


       
      
       
       
 
    }
}
