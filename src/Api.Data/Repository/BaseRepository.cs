using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
  public class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
      protected readonly MyContext _context;
      private DbSet<T> _dataset;
      

      //Para construir o Construtor
      public BaseRepository(MyContext context)
      {
          _context = context;
          _dataset = _context.Set<T>();
      }
      //

    public Task<bool> DeleteAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<T> InsertAsync(T item)
    {
      try
      {
          //Para checar se o Id é vazio
           if (item.Id == Guid.Empty) {
               item.Id = Guid.NewGuid();
           }

           item.CreateAt = DateTime.UtcNow;
           _dataset.Add(item);

           await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
          throw ex;
      }

      return item;
    }

    public Task<IEnumerable<T>> SelecAsync()
    {
      throw new NotImplementedException();
    }

    public Task<T> SelectAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T item)
    {
      throw new NotImplementedException();
    }
  }
}