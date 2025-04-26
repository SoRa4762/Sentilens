using api.Core.Entities.Base;
using api.Core.Interfaces.Base;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private protected readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("FOREIGN KEY") == true)
            {
                throw new ApplicationException("A foreign key constraint was violated. Please ensure all related entities exist.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while adding the entity.", ex);
            }
        }

        // something wrong with this method
        //public async Task<T> AddRangeAsync(IReadOnlyList<T> entities)
        //{
        //    try
        //    {
        //        await _context.Set<T>().AddRangeAsync(entities);
        //        await _context.SaveChangesAsync();
        //        return entities.FirstOrDefault(e => e == entities);
        //    }
        //    catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("FOREIGN KEY") == true)
        //    {
        //        throw new ApplicationException("A foreign key constraint was violated. Please ensure all related entities exist.", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("An unexpected error occurred while adding the entities.", ex);
        //    }
        //}
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            //var isEntity = await _context.Set<T>().FindAsync(entity);
            //if (isEntity)
            //{

            //}
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
